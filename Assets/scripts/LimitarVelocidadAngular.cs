using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitarVelocidadAngular : MonoBehaviour
{
    public float maxAngularSpeed = 10f; // Ajusta este valor seg�n lo que sea adecuado para tu juego
    private Rigidbody rb;
    private float alturaLanzamiento;
    PlayerMovement scriptJugador;
    void Start()
    {
        GameObject jugador = GameObject.Find("character");
        
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularSpeed;


        if (jugador != null)
        {
            // Accede al script ScriptJugador en el GameObject del jugador
            scriptJugador = jugador.GetComponent<PlayerMovement>();

            if (scriptJugador != null)
            {
                // Accede a la variable p�blica alturaLanzamiento del ScriptJugador
                alturaLanzamiento = scriptJugador.Basicforze;
                
            }
        }

    }

    void Update()
    {
        if (scriptJugador.getIsFlyBall() == true)
        {
            rb.AddForce(0,alturaLanzamiento,0);
        }
        
    }
}
