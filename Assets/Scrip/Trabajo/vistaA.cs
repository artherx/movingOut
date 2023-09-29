using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vistaA : MonoBehaviour
{
   
    private void Update() 
    {
        colicion();
    
    }
    private void colicion()
    {
        Debug.Log(transform.childCount);
        for(int i=0; i<transform.childCount-1;i++)
        {
            Debug.Log("!primera entrada");
            for(int j=0+i; j<transform.childCount-1;j++)
            {Debug.Log("!segunda entrada");
                objeto obj0 = transform.GetChild(j).GetComponent<objeto>();
                objeto obj1 = transform.GetChild(j+1).GetComponent<objeto>();
                Vector3 distancia=obj0.transform.position-obj1.transform.position;
                Debug.Log(distancia+"i: "+i+"j: "+j);
            }
        }
    }
}
