using System;
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
    private Vector3 scala;
    public float masa=0f;
    public float vfx=0f;
    public float vfy=0f;
    public float vfz=0f;
    
    
    
    
    private void Start()
    {
        al = transform.localScale.y/2;
        an = transform.localScale.x/2;
        pf = transform.localScale.z/2;
        scala=new Vector3(an,al,pf);
    }
    private void Update() {
        transform.Translate(new Vector3(1*vfx,1*vfy,1*vfz)*Time.deltaTime);
    }
    private void setCollideR()
    {
        Color color = Color.green;
        ub = transform.position;
        puntos[0]=new Vector3(al+ub.x, an+ub.y, pf+ub.z);
        puntos[1]=new Vector3(-al+ub.x, an+ub.y, pf+ub.z);
        puntos[2]=new Vector3(-al+ub.x, -an+ub.y, pf+ub.z);
        puntos[3]=new Vector3(al+ub.x, -an+ub.y, pf+ub.z);

        puntos[4]=new Vector3(-al+ub.x, an+ub.y, -pf+ub.z);
        puntos[5]=new Vector3(-al+ub.x, -an+ub.y, -pf+ub.z);

        puntos[6]=new Vector3(al+ub.x, an+ub.y, -pf+ub.z);
        puntos[7]=new Vector3(al+ub.x, -an+ub.y, -pf+ub.z);
        Debug.DrawLine(puntos[0], puntos[1], color);
        

        
    }
    public Vector3 PuntoMinimo(objeto obj)
    {
        setCollideR();
        Vector3 p1 = obj.transform.position + obj.scala;
        Vector3 p2 = obj.transform.position - obj.scala;
        Vector3 minimo = new Vector3(MathF.Min(p1.x,p2.x),MathF.Min(p1.y,p2.y),MathF.Min(p1.z,p2.z));
        return minimo;
    }
    public Vector3 PuntoMaximo(objeto obj)
    {
        setCollideR();
        Vector3 p1 = obj.transform.position + obj.scala;
        Vector3 p2 = obj.transform.position - obj.scala;
        Vector3 maximo = new Vector3(MathF.Max(p1.x,p2.x),MathF.Max(p1.y,p2.y),MathF.Max(p1.z,p2.z));
        return maximo;
        
    }
}
