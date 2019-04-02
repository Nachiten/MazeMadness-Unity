using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    //Variables
    GameObject referencia;
    GameObject textoVelocidad;
    Rigidbody rb;
    Text texto;
    float speed = 17;
    float maxSpeed = 27;

    /* -------------------------------------------------------------------------------- */

    // Llamado al inicio
    void Start()
    {
        referencia = GameObject.FindGameObjectWithTag("Referencia");
        
        rb = GetComponent<Rigidbody>();
    }

    /* -------------------------------------------------------------------------------- */

    // Se llama cada fotograma
    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddForce(moverVertical * referencia.transform.forward * speed);
        rb.AddForce(moverHorizontal * referencia.transform.right * speed);
    }

    /* -------------------------------------------------------------------------------- */

    public void AjustarVelocidad(float velocidad)
    {
        speed = velocidad * 10 + 12;

        textoVelocidad = GameObject.FindGameObjectWithTag("Numero Velocidad");
        texto = textoVelocidad.GetComponent<Text>();

        texto.text = (velocidad * 20 + 10).ToString("F2");
    }

}


 