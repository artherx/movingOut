using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject manos;
    public GameObject manoI;
    public GameObject manoD;
    private GameObject pickObjetc = null;
    private Vector3 mIVector;
    private Vector3 mDVector;

    // Update is called once per frame
    void Update()
    {
        if(pickObjetc!=null)
        {
            if(Input.GetKey("e")||Input.GetMouseButtonDown(1))
            {
                pickObjetc.GetComponent<Rigidbody>().useGravity = true;
                pickObjetc.GetComponent<Rigidbody>().isKinematic = false;
                pickObjetc.gameObject.transform.SetParent(null);
                pickObjetc = null;
            }
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("objeto"))
        {
            if (Input.GetKey("e")||Input.GetMouseButtonDown(1)&&pickObjetc==null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = manos.transform.position;
                other.gameObject.transform.SetParent(manos.gameObject.transform);
                pickObjetc = other.gameObject;
                mIVector = manoI.transform.position;
                mDVector = manoD.transform.position;
                //Mover manos al objetos
                manoD.transform.position = other.transform.position;
                manoI.transform.position = other.transform.position;
            }
        }
    }
}
