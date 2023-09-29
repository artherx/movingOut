using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeto : MonoBehaviour
{
    private float al; 
    private float an;
    private float pf; 
    private Vector3 ub;
    private Vector3[] puntos= new Vector3[8];
    void Update()
    {
        al = transform.localScale.y/2;
        an = transform.localScale.x/2;
        pf = transform.localScale.z/2;
        ub=transform.position;
    }
    
    private void setCollideR()
    {
        ub = transform.position;
        puntos[0]=new Vector3(al+ub.x, an+ub.y, pf+ub.z);
        puntos[1]=new Vector3(-al+ub.x, an+ub.y, pf+ub.z);
        puntos[2]=new Vector3(-al+ub.x, -an+ub.y, pf+ub.z);
        puntos[3]=new Vector3(al+ub.x, -an+ub.y, pf+ub.z);

        puntos[4]=new Vector3(-al+ub.x, an+ub.y, -pf+ub.z);
        puntos[5]=new Vector3(-al+ub.x, -an+ub.y, -pf+ub.z);

        puntos[6]=new Vector3(al+ub.x, an+ub.y, -pf+ub.z);
        puntos[7]=new Vector3(al+ub.x, -an+ub.y, -pf+ub.z);
    }
    private void colicion(objeto other)
    {
        Vector3 disV = other.ub-ub;
        float distM = disV.magnitude;
        float minSX = an + other.an;
        float minSY = al + other.al;
        float minSZ = pf + other.pf;

        if(distM <minSX||distM <minSY||distM <minSZ)
        {
            
        }
    }
}
