using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public colisonador[] colisonador;
    // Start is called before the first frame update
    void Start()
    {




        for (int K = 0; K < colisonador.Length; K++)
        {
            colisonador[K].booleanos(colisonador.Length-K);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int K = 0; K < colisonador.Length; K++)
        {
            colisonador[K].Actualizar();
            colisonador[K].DetectarColisionPared();
        }
        
        for (int K = 0; K < colisonador.Length - 1; K++)
        {
            for (int i = 0+K; i < colisonador.Length - 1; i++)
            {
                colisonador[K].verificarColision(colisonador[i+1],i);
            }

        }
        
    }
}
