using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romperobjeto : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <-50)
        {
            /*transform.position = new Vector3(1,2,7);
            transform.rotation = Quaternion.Euler(0,0,0);*/
            Destroy(gameObject);
        }
    }
}
