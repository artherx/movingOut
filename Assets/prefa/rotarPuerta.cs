using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class rotarPuerta : MonoBehaviour
{
    public botomP bot;
    private Quaternion rotIn= Quaternion.identity;
    private Quaternion rotIn1= Quaternion.identity;
    private Quaternion rotInx= Quaternion.identity;
    private Quaternion rotInx1= Quaternion.identity;
    private Quaternion rotIny= Quaternion.identity;
    private Quaternion rotIny1= Quaternion.identity;
    private Quaternion rotInz= Quaternion.identity;
    private Quaternion rotInz1= Quaternion.identity;
    private float anguloV = .5f;
    private Vector3 angulo =new Vector3(0,90,0);
    private float SinAngu =0;
    private float CosAngu =0;
    private Quaternion qx =Quaternion.identity;
    private Quaternion qy=Quaternion.identity;
    private Quaternion qz=Quaternion.identity;
    private Quaternion p=Quaternion.identity;
    private Quaternion pato=Quaternion.identity;

    private void Start()
    {
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*transform.rotation.x/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*transform.rotation.x/2);
        rotInx.Set(SinAngu,0,0,CosAngu);
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*transform.rotation.y/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*transform.rotation.y/2);
        rotIny.Set(0,SinAngu,0,CosAngu);
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*transform.rotation.z/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*transform.rotation.z/2);
        rotInz.Set(0,0,SinAngu,CosAngu);

        rotIn=rotInz*rotIny*rotInx;
        

        
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*angulo.x/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*angulo.x/2);
        qx.Set(SinAngu,0,0,CosAngu);
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*angulo.y/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*angulo.y/2);
        qy.Set(0,SinAngu,0,CosAngu);
        SinAngu = Mathf.Sin(Mathf.Deg2Rad*angulo.z/2);
        CosAngu = Mathf.Cos(Mathf.Deg2Rad*angulo.z/2);
        qz.Set(0,0,SinAngu,CosAngu);
        p = qz*qy*qx;
    }

    private void Update()
    {
        float velo = anguloV * Time.deltaTime;
        print(bot.getLim());
        float anguloTotal = Quaternion.Angle(transform.rotation, p);

        // Calcula el ángulo en el tiempo t = velo
        float theta = velo * anguloTotal;

        // Calcula los pesos para la mezcla lineal
        float weightStart = Mathf.Sin((1 - velo) * theta) / Mathf.Sin(theta);
        float weightEnd = Mathf.Sin(velo * theta) / Mathf.Sin(theta);
        if (bot.getLim() == true)
        {
            print("moviendo puerta" + Quaternion.Angle(transform.rotation,p));
            pato.w = weightStart * transform.rotation.w + weightEnd * p.w;
            pato.x = weightStart * transform.rotation.x + weightEnd * p.x;
            pato.y = weightStart * transform.rotation.y + weightEnd * p.y;
            pato.z = weightStart * transform.rotation.z + weightEnd * p.z;
            
            transform.rotation = pato;
        }
        else
        {
            print("moviendo puerta" + Quaternion.Angle(transform.rotation,p));
            pato.w = weightStart * transform.rotation.w + weightEnd * rotIn.w;
            pato.x = weightStart * transform.rotation.x + weightEnd * rotIn.x;
            pato.y = weightStart * transform.rotation.y + weightEnd * rotIn.y;
            pato.z = weightStart * transform.rotation.z + weightEnd * rotIn.z;
            
            transform.rotation = pato;
        }
    }
}
