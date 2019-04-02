using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadController : MonoBehaviour
{
    GameObject Jugador;
    PlayerMovement script;

    /* -------------------------------------------------------------------------------- */

    public void velocidad(float valor)
    {
        // Asignar objeto Jugador
        Jugador = GameObject.FindGameObjectWithTag("Jugador");

        // Asignar script
        script = Jugador.GetComponent<PlayerMovement>();

        // Ejecutar funcion para editar valor
        script.AjustarVelocidad(valor);
    }
}
