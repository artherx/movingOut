using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class colisonador : MonoBehaviour
{
    public GameObject entorno;
    Vector3 velocidad, ScaleEntorno;
    public float velx, vely, velz, masa;
    private float radio;
    bool[] colision;



    // Start is called before the first frame update
    void Start()
    {
        velocidad.Set(velx,vely,velz);
        radio = transform.localScale.y/2;
        ScaleEntorno = entorno.transform.localScale;

    }

    public void Actualizar()
    {
        transform.position = transform.position + velocidad;
    }

    public void booleanos(int max)
    {
         colision = new bool[max];
    }



    public void DetectarColisionPared() {
        //paredes x
    if (transform.position.x > entorno.transform.position.x + (entorno.transform.localScale.x / 2)-radio ) {
      transform.position = new Vector3 (entorno.transform.position.x + (entorno.transform.localScale.x / 2)-radio,transform.position.y,transform.position.z);
      velocidad.x = velocidad.x * - 1;
    } else if (transform.position.x < entorno.transform.position.x - (entorno.transform.localScale.x / 2)+radio ) {
            transform.position = new Vector3(entorno.transform.position.x - (entorno.transform.localScale.x / 2)+radio , transform.position.y, transform.position.z);
            velocidad.x = velocidad.x * -1;
    }
        //paredes y
        else if (transform.position.y > entorno.transform.position.y + (entorno.transform.localScale.y / 2) - radio)
        {
            transform.position = new Vector3(transform.position.x, entorno.transform.position.y + (entorno.transform.localScale.y / 2) - radio, transform.position.z);
            velocidad.y = velocidad.y * -1;
        }
        else if (transform.position.y < entorno.transform.position.y - (entorno.transform.localScale.y / 2) + radio)
        {
            transform.position = new Vector3(transform.position.x, entorno.transform.position.y - (entorno.transform.localScale.y / 2) + radio, transform.position.z);
            velocidad.y = velocidad.y * -1;
        }
    //paredes z
        else if (transform.position.z > entorno.transform.position.z + (entorno.transform.localScale.z / 2) - radio)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, entorno.transform.position.z + (entorno.transform.localScale.z / 2) - radio);
            velocidad.z = velocidad.z * -1;
        }
        else if (transform.position.z < entorno.transform.position.z - (entorno.transform.localScale.z / 2) + radio)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, entorno.transform.position.z - (entorno.transform.localScale.z / 2) + radio);
            velocidad.z = velocidad.z * -1;
        }
    }

    public void verificarColision(colisonador OtherBall,int num)
    {
        
        Vector3 distanciaVec = (OtherBall.transform.position - transform.position);
        float distancia = distanciaVec.magnitude;
        float disMin = radio + OtherBall.radio;

        if (distancia <= disMin && colision[num] ==false)
        {
            colision[num] = true;
            // conseguimos el angulo del vector distancia
            float theta = Vector3.Angle(distanciaVec, transform.forward);
            // calculamos seno y coseno del angulo
            float sine = Mathf.Sin(theta);
            float cosine = Mathf.Cos(theta);
            //creamos un vector que guarde las rotaciones del mundo deacuerdo al angulo de la distancia para la linea de accion
            Vector3[] bTemp = { new Vector3(), new Vector3() };

            bTemp[1].x = cosine * distanciaVec.x + sine * distanciaVec.y;
            bTemp[1].y = cosine * distanciaVec.y - sine * distanciaVec.x;

            //rotamos vectores de velocidad
            Vector3[] vTemp = {
        new Vector3(), new Vector3()
      };
            vTemp[0].x = cosine * velocidad.x + sine * velocidad.y;
            vTemp[0].y = cosine * velocidad.y - sine * velocidad.x;
            vTemp[1].x = cosine * OtherBall.velocidad.x + sine * OtherBall.velocidad.y;
            vTemp[1].y = cosine * OtherBall.velocidad.y - sine * OtherBall.velocidad.x;

            //ahora las velocidades son rotadas, usamos la ecuacion de concervacion del momentum para calcular la velocidad final 
            Vector3[] vFinal = {
        new Vector3(), new Vector3()
      };

            // al final rotamos las velocidades por b[0]
            vFinal[0].x = ((masa - OtherBall.masa) * vTemp[0].x + 2 * OtherBall.masa * vTemp[1].x) / (masa + OtherBall.masa);
            vFinal[0].y = vTemp[0].y;

            // al final rotamos velocidades porb[0]
            vFinal[1].x = ((OtherBall.masa - masa) * vTemp[1].x + 2 * masa * vTemp[0].x) / (masa + OtherBall.masa);
            vFinal[1].y = vTemp[1].y;

            bTemp[0].x += vFinal[0].x;
            bTemp[1].x += vFinal[1].x;

            //rotamos de forma inversa para recuperar la posicion inicial
            Vector3[] bFinal = {
        new Vector3(), new Vector3()
      };

            bFinal[0].x = cosine * bTemp[0].x - sine * bTemp[0].y;
            bFinal[0].y = cosine * bTemp[0].y + sine * bTemp[0].x;
            bFinal[1].x = cosine * bTemp[1].x - sine * bTemp[1].y;
            bFinal[1].y = cosine * bTemp[1].y + sine * bTemp[1].x;

            //
            Vector3 pos;
            // actualizamos la posicion de la pantalla
            pos.x = transform.position.x + bFinal[1].x;
            pos.y = transform.position.y + bFinal[1].y;
            pos.z = OtherBall.transform.position.z;
            OtherBall.transform.position = pos;

            transform.position = transform.position + (bFinal[0]);

            // actualizamos velocidades
            velocidad.x = cosine * vFinal[0].x - sine * vFinal[0].y;
            velocidad.y = cosine * vFinal[0].y + sine * vFinal[0].x;
            OtherBall.velocidad.x = cosine * vFinal[1].x - sine * vFinal[1].y;
            OtherBall.velocidad.y = cosine * vFinal[1].y + sine * vFinal[1].x;
        }
        else
        {
            colision[num] = false;
        }
    }
}
