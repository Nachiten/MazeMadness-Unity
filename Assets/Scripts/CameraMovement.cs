using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

    // Variables
    float sensibilidad = 2;
    GameObject textoSensiblidad;
    Text texto;
    GameObject jugador;
    GameObject referencia;
    Vector3 distancia;
    public Transform bolaTransform;

    /* -------------------------------------------------------------------------------- */

    // Se ejecuta una unica vez al iniciar
    void Start()
    {
        // Asignar los Game Objects
        referencia = GameObject.FindGameObjectWithTag("Referencia");
        jugador = GameObject.FindGameObjectWithTag("Jugador");

        //Asignar Distancia
        distancia = transform.position - jugador.transform.position;

       //  gameObject.transform.position = bolaTransform.position;
    }

    /* -------------------------------------------------------------------------------- */

    // Es llamado despues de cada fotograma
    void LateUpdate()
    {
        // Calcula la distancia del jugador
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * distancia;
        // La camara cambia su posicion respecto a la posicion del jugador
        transform.position = jugador.transform.position + distancia;
        // La camara mira hacia el jugador
        transform.LookAt(jugador.transform.position);

        // Referencia para que los controles no cambien
        Vector3 copiarRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        // Rotar la referencia
        referencia.transform.eulerAngles = copiarRotacion;

    }

    /* -------------------------------------------------------------------------------- */

    public void AjustarSensibilidad(float velocidad)
    {
        textoSensiblidad = GameObject.FindGameObjectWithTag("Numero Sensibilidad");
        sensibilidad = velocidad * 4 + 1;
        texto = textoSensiblidad.GetComponent<Text>();

        texto.text = (sensibilidad/2).ToString("F2");
    }


}
