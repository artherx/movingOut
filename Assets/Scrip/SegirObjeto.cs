using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegirObjeto : MonoBehaviour
{
     public Transform objetoASeguir;
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (objetoASeguir != null)
        {
            Vector3 desiredPosition = new Vector3(objetoASeguir.position.x, transform.position.y, objetoASeguir.position.z-20);
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
