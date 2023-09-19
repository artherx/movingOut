using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible: MonoBehaviour
{
   public GameObject ventanarota;
   private void OnTriggerEnter(Collider other) 
   {
     if (other.CompareTag("Player"))
    {
        Instantiate(ventanarota, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
   }
}
