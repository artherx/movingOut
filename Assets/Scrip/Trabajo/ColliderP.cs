using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderP : MonoBehaviour
{
    public bool objeto;
    public bool colicion = true;
    private float altura; 
    private float ancho;
    private float profundidad; 
    private float vgravedad;
    public float masa=1;
    private Vector3 ubicacion;
    void Start()
    {
        altura = transform.localScale.y;
        ancho = transform.localScale.x;
        profundidad = transform.localScale.z;
        ubicacion=transform.position;
        if(masa == 0) masa = 1;
        Debug.Log("Altura: " + altura+"Profundidad: " + profundidad+"Ancho: " + ancho);
        Debug.Log("x: " + ubicacion.x+"y: " + ubicacion.y+"z: " + ubicacion.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        gravedad(objeto);
        Rcolicion();
    }
    private void gravedad(bool obj)
    {
        if (obj == true)
        {
            vgravedad -= 9.8f*Time.deltaTime*masa;
            ubicacion.y+=vgravedad;
            transform.position=ubicacion;
            Debug.Log("x: " + ubicacion.x+"y: " + ubicacion.y+"z: " + ubicacion.z+"ubi: "+ vgravedad);
        }
    }
    private void Rcolicion()
    {
        if(colicion==true)
        {
            Debug.Log("Coliciono");
        }
        else
        Debug.Log("no coli");
    }
}
