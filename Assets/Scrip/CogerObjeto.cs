using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject manos;
    public GameObject manoI;
    public GameObject manoD;
    public float fuerzaLanza = 1000f;
    private GameObject pickObjetc = null;
    public GameObject personaje = null;
    private Vector3 mIPos,mIRot;
    private Vector3 mDPos,mDRot;
    
    private float t1,t2;
    private bool t3 = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && pickObjetc!=null && Input.GetKey("f")!=true)
        {
            pickObjetc.GetComponent<Rigidbody>().useGravity = true;
            pickObjetc.GetComponent<Rigidbody>().isKinematic = false;
            pickObjetc.gameObject.transform.SetParent(null);
            pickObjetc = null;
            Debug.Log("soltar objeto");
            
        }
        if(Input.GetMouseButton(1) && pickObjetc!=null)
        {
            t1= Time.time;
            t3=true;
            pickObjetc.GetComponent<Rigidbody>().useGravity = true;
            pickObjetc.GetComponent<Rigidbody>().isKinematic = false;
            pickObjetc.gameObject.transform.SetParent(null);
            pickObjetc.GetComponent<Rigidbody>().AddForce((personaje.transform.forward+new Vector3(0,1,0))*fuerzaLanza);
            
            pickObjetc = null;
            Debug.Log("lanzar objeto"+ transform.forward+"con fuerza:"+ transform.forward*fuerzaLanza);
            

        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("objeto"))
        {
            t2= Time.time;
            if(t2-t1>=0.50&& t3==true) t3 = false;
            Debug.Log("objeto en rango");
            if (Input.GetMouseButton(0) && pickObjetc==null&&t3==false)
            {
                Debug.Log(t2-t1);
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = manos.transform.position;
                other.gameObject.transform.SetParent(manos.gameObject.transform);
                pickObjetc = other.gameObject;
                
                Debug.Log("agarrar objeto");
            }
        }
    }
}
