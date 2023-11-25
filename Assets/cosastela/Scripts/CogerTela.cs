using UnityEngine;

public class AgarrarSoltarLanzarTela : MonoBehaviour
{
    public Transform hand;
    public float distanciaDeLanzamiento = 5f;

    private Transform tela;
    private bool telaAgarrada = false;

    void Start()
    {
        tela = GameObject.FindGameObjectWithTag("Tela").transform;

        if (tela == null)
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'Tela'");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (telaAgarrada)
            {
                SoltarYLanzarTela();
            }
            else
            {
                AgarrarTela();
            }
        }
    }

    void AgarrarTela()
    {
        tela.parent = hand;
        tela.localPosition = Vector3.zero;
        tela.localRotation = Quaternion.identity;
        telaAgarrada = true;
    }

    void SoltarYLanzarTela()
    {
        tela.parent = null;
        telaAgarrada = false;

        // Calcula la dirección del lanzamiento y aplica el desplazamiento
        Vector3 direccionLanzamiento = hand.forward;
        tela.Translate(direccionLanzamiento * distanciaDeLanzamiento, Space.World);
    }
}
