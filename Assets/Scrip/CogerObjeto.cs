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
    private Vector3 mIPos,mIRot;
    private Vector3 mDPos,mDRot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("e")&&pickObjetc!=null && Input.GetKey("f")!=true)
        {
           
            manoD.transform.position = mIPos + manos.transform.position;
            manoI.transform.position = mDPos + manos.transform.position;
            pickObjetc.GetComponent<Rigidbody>().useGravity = true;
            pickObjetc.GetComponent<Rigidbody>().isKinematic = false;
            pickObjetc.gameObject.transform.SetParent(null);
            pickObjetc = null;
            Debug.Log("soltar objeto");
            
        }
        if(Input.GetKey("f")&&pickObjetc!=null&& Input.GetKey("e") != true)
        {
            
            manoD.transform.rotation = manos.transform.rotation;
            manoI.transform.rotation = manos.transform.rotation;
            pickObjetc.GetComponent<Rigidbody>().useGravity = true;
            pickObjetc.GetComponent<Rigidbody>().isKinematic = false;
            pickObjetc.gameObject.transform.SetParent(null);
            pickObjetc.GetComponent<Rigidbody>().AddForce((transform.forward+new Vector3(0,2,0))*fuerzaLanza);
            
            pickObjetc = null;
            Debug.Log("lanzar objeto"+ transform.forward+"con fuerza:"+ transform.forward*fuerzaLanza);
            

        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("objeto"))
        {
            Debug.Log("objeto en rango");
            if (Input.GetKey("e")&&pickObjetc==null)
            {
                Debug.Log("woaos");
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = manos.transform.position;
                other.gameObject.transform.SetParent(manos.gameObject.transform);
                pickObjetc = other.gameObject;
                mIPos = manoI.transform.position - manos.transform.position;
                mDPos = manoD.transform.position - manos.transform.position;
                //Mover manos al objetos
                manoD.transform.position = other.transform.position;
                manoI.transform.position = other.transform.position;
                Debug.Log("agarrar objeto");
            }
        }
    }
}
