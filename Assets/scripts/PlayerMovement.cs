using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float jumpForce;
    public float movespeed = 5.0f, rotationSpeed = 10.0f;
    public float Basicforze = 1.0f;
    private float grabCooldown=0.0f;

    private GameObject objeto=null;
    public Transform posDribble;
   


    private bool IsObjectNear = false;
    private bool IsObjectinHands = false;
    private bool IsFlyBall = false;
    Rigidbody rb;

    public bool getIsFlyBall()
    {
        return IsFlyBall;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }


    // Update is called once per frame
    void Update()
    {
        
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1) && IsObjectNear) { }
        else
        {
            transform.Translate(inputDirection * movespeed * Time.deltaTime, Space.World);
            

        }



        //ball in hands
        if (IsObjectNear == true && Input.GetMouseButton(0))
        {
            IsObjectinHands=true;
            if (Input.GetMouseButton(1))
            {
                objeto.transform.position = posDribble.position;
                objeto.transform.rotation = posDribble.rotation;
            }
            else
            {
                objeto.GetComponent<Rigidbody>().isKinematic = true;
                objeto.transform.position = posDribble.position;
                objeto.transform.rotation = posDribble.rotation;
            }
            if (Input.GetMouseButtonUp(1))
            {
                
                objeto.GetComponent<Rigidbody>().isKinematic = false;
                IsObjectNear = false;
                IsObjectinHands = false;
                IsFlyBall = true;
                grabCooldown=Time.time;
            }
            if (IsFlyBall)
            {
                Vector3 directionBall = transform.forward;
                objeto.GetComponent<Rigidbody>().velocity = ((directionBall.normalized + Vector3.up) * (Basicforze));
                IsFlyBall = false;
            }
        }
        else if (IsObjectNear == true)
        {
            IsObjectinHands = false;
            objeto.GetComponent<Rigidbody>().isKinematic = false;
            
        }



        if (Input.GetKey(KeyCode.Space) && checkGround.isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }






    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "objeto"&&Time.time>grabCooldown+0.2 && objeto == null && IsObjectinHands == false)
        {
            Debug.Log("Xd");
            objeto = other.gameObject;
            IsObjectNear = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "objeto" && objeto != null && IsObjectinHands==false)
        {
            Debug.Log("A");
            objeto = null;
            IsObjectNear = false;
        }

    }
}
    



