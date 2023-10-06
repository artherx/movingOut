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
                
                float aux = 1.0f/(obj0.masa+obj1.masa);
                float vps1 = (obj0.masa - e * obj1.masa) * aux * obj0.vfx + (1.0f + e) * obj1.masa * obj1.vfx * aux;
                float vps2 = (1.0f + e) * obj0.masa * obj0.vfx * aux + (obj1.masa - e * obj0.masa) * obj1.vfx * aux;

                if(distancia<=0.1+obj0.transform.localScale.x)
                {
                    
                }
                                
                Debug.Log(distancia+"i: "+i+"j: "+j);
            }
        }
    }
}
