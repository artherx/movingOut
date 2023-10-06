using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potencia : MonoBehaviour
{
    private float acelerator = 0.4f;
    private void Update() {
        
        transform.position= new Vector3(acelerator,0,0);
        acelerator+=acelerator;
    }
    
}
