using UnityEngine;

public class SeguirJugadorIsometrico : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Posici�n relativa de la c�mara respecto al jugador

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Obtener la nueva posici�n de la c�mara en base a la posici�n del jugador y el offset
            Vector3 nuevaPosicion = jugador.position + offset;

            // Asignar la nueva posici�n a la c�mara
            transform.position = nuevaPosicion;

            // Apuntar la c�mara hacia el jugador (vista isom�trica)
            transform.LookAt(jugador.position);
            transform.eulerAngles = new Vector3(45f, transform.eulerAngles.y, 0f); // Rotar la c�mara en un �ngulo isom�trico
        }
    }
}

