using UnityEngine;
using System.Collections; // Necesario para usar el temporizador (WaitForSeconds)

public class Camaras : MonoBehaviour
{
    [Header("Lista de Cámaras en Orden")]
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private GameObject camera3;
    [SerializeField] private GameObject camera4; // Se mantiene la variable para no romper referencias, pero ya no se usa.

    [Header("Configuración del Recorrido")]
    [SerializeField] private float tiempoPorCamara = 2.0f; // Tiempo que dura cada vista

    // Esta variable guardará cuál cámara tocará activar (1, 2, 3 o 4)
    private int camaraActual = 1;
    private bool ejecutandoSecuencia = false;

    void Start()
    {
        // Al empezar la partida, aseguramos que inicie en la cámara 1
        ActualizarCamaras();
    }

    void OnTriggerEnter(Collider collision)
    {
        // Cada vez que el jugador ENTRA al trigger, inicia la secuencia si no está corriendo ya
        if (collision.CompareTag("Player") && !ejecutandoSecuencia)
        {
            StartCoroutine(SecuenciaDeCamaras());
        }
    }

    // Corrutina que hace el recorrido por los 3 puntos y regresa automáticamente al inicio
    private IEnumerator SecuenciaDeCamaras()
    {
        ejecutandoSecuencia = true;

        // --- PUNTO DE VISTA 1 ---
        camaraActual = 1;
        ActualizarCamaras();
        yield return new WaitForSeconds(tiempoPorCamara);

        // --- PUNTO DE VISTA 2 ---
        camaraActual = 2;
        ActualizarCamaras();
        yield return new WaitForSeconds(tiempoPorCamara);

        // --- PUNTO DE VISTA 3 ---
        camaraActual = 3;
        ActualizarCamaras();
        yield return new WaitForSeconds(tiempoPorCamara);

        camaraActual = 4;
        ActualizarCamaras();
        yield return new WaitForSeconds(tiempoPorCamara);
        // --- REGRESO AUTOMÁTICO A LA POSICIÓN INICIAL ---
        camaraActual = 1;
        ActualizarCamaras();

        ejecutandoSecuencia = false;
    }

    // Método para apagar todas las cámaras y solo encender la que corresponde
    private void ActualizarCamaras()
    {
        camera1.SetActive(camaraActual == 1);
        camera2.SetActive(camaraActual == 2);
        camera3.SetActive(camaraActual == 3);
        camera4.SetActive(camaraActual == 4); // Se queda en falso siempre ya que camaraActual nunca llega a 4
    }
}