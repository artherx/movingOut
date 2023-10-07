using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vistaA : MonoBehaviour
{
   
    private float e = 0.9f;
    private void Update() 
    {
        colicion();
    
    }
    private void colicion()
    {
        Debug.Log(transform.childCount);
        for(int i=0; i<transform.childCount-1;i++)
        {
            for(int j=0+i; j<transform.childCount-1;j++)
            {
                objeto obj0 = transform.GetChild(j).GetComponent<objeto>();
                objeto obj1 = transform.GetChild(j+1).GetComponent<objeto>();
                float distancia= Vector3.Distance(obj0.transform.position,obj1.transform.position);
                if(distancia<=0.1+obj0.transform.localScale.x&& obj0.plano!=true&&obj1.plano!=true)
                {
                    Vector3 veto = (obj0.transform.position-obj1.transform.position).normalized;
                    float alfa = Mathf.Acos(veto.x/distancia);
                    float beta = Mathf.Acos(veto.y/distancia);
                    float gama = Mathf.Acos(veto.z/distancia);
                    
                    
                    float aux = 1.0f/(obj0.masa+obj1.masa);
                    float vx0 = (obj0.masa - e * obj1.masa) * aux * obj0.vfx + (1.0f + e) * obj1.masa * obj1.vfx * aux;
                    float vx1 = (1.0f + e) * obj0.masa * obj0.vfx * aux + (obj1.masa - e * obj0.masa) * obj1.vfx * aux;

                    float vy0 = (obj0.masa - e * obj1.masa) * aux * obj0.vfy + (1.0f + e) * obj1.masa * obj1.vfy * aux;
                    float vy1 = (1.0f + e) * obj0.masa * obj0.vfy * aux + (obj1.masa - e * obj0.masa) * obj1.vfy * aux;

                    float vz0 = (obj0.masa - e * obj1.masa) * aux * obj0.vfz + (1.0f + e) * obj1.masa * obj1.vfz * aux;
                    float vz1 = (1.0f + e) * obj0.masa * obj0.vfz * aux + (obj1.masa - e * obj0.masa) * obj1.vfz * aux;
                    obj0.vfx=vx0;
                    obj1.vfx=vx1;

                    obj0.vfy=vy0;
                    obj1.vfy=vy1;

                    obj0.vfz=vz0;
                    obj1.vfz=vz1;


                    /*
                    obj0.vfx=vx0*(Mathf.Cos(beta)*Mathf.Cos(gama)+Mathf.Cos(beta)*Mathf.Sin(gama)-Mathf.Sin(gama));
                    obj1.vfx=vx1*(Mathf.Cos(beta)*Mathf.Cos(gama)+Mathf.Cos(beta)*Mathf.Sin(gama)-Mathf.Sin(gama));

                    obj0.vfy=vy0*(+(Mathf.Cos(alfa)*Mathf.Sin(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Cos(gama))+(-Mathf.Cos(alfa)*Mathf.Sin(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Sin(gama))+Mathf.Cos(beta)*Mathf.Sin(alfa));
                    obj1.vfy=vy1*(+(-Mathf.Cos(alfa)*Mathf.Sin(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Cos(gama))+(-Mathf.Cos(alfa)*Mathf.Sin(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Sin(gama))+Mathf.Cos(beta)*Mathf.Sin(alfa));

                    obj0.vfz=vz0*(+(Mathf.Sin(alfa)*Mathf.Sin(gama)+Mathf.Cos(alfa)*Mathf.Sin(beta)*Mathf.Cos(gama))+(-Mathf.Cos(alfa)*Mathf.Cos(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Sin(gama))-Mathf.Cos(beta)*Mathf.Sin(alfa));
                    obj1.vfz=vz1*(+(Mathf.Sin(alfa)*Mathf.Sin(gama)+Mathf.Cos(alfa)*Mathf.Sin(beta)*Mathf.Cos(gama))+(-Mathf.Cos(alfa)*Mathf.Cos(gama)+Mathf.Sin(alfa)*Mathf.Sin(beta)*Mathf.Sin(gama))-Mathf.Cos(beta)*Mathf.Sin(alfa));*/
                }
                else
                {
                    if(obj0==true)
                    {
                        Vector3 mx=obj0.PuntoMaximo(obj0);
                        Vector3 mn =obj0.PuntoMinimo(obj0);
                    }
                    if(obj1==true)
                    {
                        
                    }
                }
                                
                Debug.Log(distancia+"i: "+i+"j: "+j);
            }
        }
    }
}
