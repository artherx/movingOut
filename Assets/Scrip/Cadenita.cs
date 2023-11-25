using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenita : MonoBehaviour
{
    public Vector3 fuerzaPrueba;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el trigger es el objeto deseado.
        if (other.CompareTag("ObjetoADetectar"))
        {
            transform.GetChild( transform.childCount-1 ).GetComponent<Rigidbody>().AddForce(fuerzaPrueba,ForceMode.Impulse);
        }
    }
}
