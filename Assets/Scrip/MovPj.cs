using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPj : MonoBehaviour
{
    public float Speed = 10.0f;
    public float Rotate = 5.0f;
    public float saltar = 5f;
    public float gravedad = 9.8f;
    private float Vgravedad;

    private CharacterController player;

    private Vector3 camForward;
    private Vector3 camRight;
    Vector3 Rota;
    
    private Vector3 lastMoveDirection = Vector3.forward;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        
        Vector3 moveDirection = new Vector3(hori,0,vert).normalized;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        
        //Rotacion
        Rota= moveDirection;
        player.transform.LookAt(player.transform.position+Rota);
        
        //Gravedad
        setGravedad();
        //salto
        if (player.isGrounded)
        {
            Vgravedad = -gravedad * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vgravedad = saltar;
                Rota.y = Vgravedad;
                Debug.Log("Ha saltado");
            }
        }
        if (transform.position.y<-20)
        {
            Rota =new Vector3(-transform.position.x,40,-transform.position.z);
            player.Move(Rota);
            
            Debug.Log("Revive");
        }
        //movimientos
        player.Move(Rota*Speed*Time.deltaTime);
        
            
        
        
    }
    
    void setGravedad()
    {
        if(player.isGrounded)
        {
            Vgravedad = -gravedad*Time.deltaTime;
            Rota.y = Vgravedad;
        }
        else 
        {
            Vgravedad -=gravedad*Time.deltaTime;
            Rota.y = Vgravedad;
        }
    }
}

