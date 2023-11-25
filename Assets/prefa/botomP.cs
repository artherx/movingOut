using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botomP : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 pos2;
    private bool pres = false;
    private bool lim = false;
    private float velo = 2f;

    private void Start()
    {
        pos = transform.position;
        pos2 = transform.position + new Vector3(0, -0.2f, 0);
    }

    private void Update()
    {
        float pasos = velo * Time.deltaTime;
        pasos = Mathf.Clamp01(pasos);
        if (pres == true)
        {
            transform.position = new Vector3
            (
                transform.position.x + (pos2.x - transform.position.x) * pasos,
                transform.position.y + (pos2.y - transform.position.y) * pasos,
                transform.position.z + (pos2.z - transform.position.z) * pasos
            );

            if (transform.position.y <= (pos.y + pos2.y))
            {
                lim = true;
                print("llega al limite");
            }
        }
        else
        {

            transform.position = new Vector3(transform.position.x + (pos.x - transform.position.x) * pasos,
             transform.position.y + (pos.y - transform.position.y) * pasos,
             transform.position.z + (pos.z - transform.position.z) * pasos);

            if (transform.position.y >= pos.y - .15f)
            {
                lim = false;

                print("salio del limite");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pres = true;
        print("entro");
    }

    private void OnTriggerExit(Collider other)
    {
        pres = false;
        print("salio");
    }

    public bool getLim()
    {
        return lim;
    }
}
