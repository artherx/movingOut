using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeto : MonoBehaviour
{
    public float masa;
    private float gavedad = 9.81f;
    private float velocidad=0;
    private Vector3 mover;
    private Vector3[] puntos = new Vector3[8];

    private void Start() {
        mover = transform.position;
        puntos[0]=new Vector3(transform.position.x+transform.localScale.x/2,transform.position.y+transform.localScale.y/2,transform.position.z+transform.localScale.z/2);
        puntos[1]=new Vector3(transform.position.x+transform.localScale.x/2,transform.position.y-transform.localScale.y/2,transform.position.z+transform.localScale.z/2);
        puntos[2]=new Vector3(transform.position.x-transform.localScale.x/2,transform.position.y-transform.localScale.y/2,transform.position.z+transform.localScale.z/2);
        puntos[3]=new Vector3(transform.position.x-transform.localScale.x/2,transform.position.y+transform.localScale.y/2,transform.position.z+transform.localScale.z/2);

        
        puntos[4]=new Vector3(transform.position.x+transform.localScale.x/2,transform.position.y-transform.localScale.y/2,transform.position.z-transform.localScale.z/2);
        puntos[5]=new Vector3(transform.position.x+transform.localScale.x/2,transform.position.y+transform.localScale.y/2,transform.position.z-transform.localScale.z/2);

        puntos[6]=new Vector3(transform.position.x+transform.localScale.x/2,transform.position.y+transform.localScale.y/2,transform.position.z-transform.localScale.z/2);
        puntos[7]=new Vector3(transform.position.x-transform.localScale.x/2,transform.position.y-transform.localScale.y/2,transform.position.z-transform.localScale.z/2);
        Debug.Log(transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        colicion();
        transform.position = mover;
        Debug.Log(transform.position);
    }
    private void gravedadV(bool suelo)
    {
        if(suelo)
        {
            velocidad =0;
            mover.y = velocidad;
            puntos[0].y = velocidad;
            puntos[1].y = velocidad;
            puntos[2].y = velocidad;
            puntos[3].y = velocidad;
            puntos[4].y = velocidad;
            puntos[5].y = velocidad;
            puntos[6].y = velocidad;
            puntos[7].y = velocidad;
        }
        else
        {
            velocidad -=gavedad*Time.deltaTime;
            mover.y += velocidad;
            puntos[0].y += velocidad;
            puntos[1].y += velocidad;
            puntos[2].y += velocidad;
            puntos[3].y += velocidad;
            puntos[4].y += velocidad;
            puntos[5].y += velocidad;
            puntos[6].y += velocidad;
            puntos[7].y += velocidad;
            Debug.Log(velocidad);
        }
    }
    private void colicion()
    {
        for(int i= 0; i<8;i++)
        {
            if(transform.position.y<=transform.localScale.y)
            {
                gravedadV(false);
                break;
            }
            else
            {
                gravedadV(true);
            }
        }
    }
}
