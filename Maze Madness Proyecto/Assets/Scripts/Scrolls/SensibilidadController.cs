using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensibilidadController : MonoBehaviour
{
    GameObject Camara;
    CameraMovement script;

    /* -------------------------------------------------------------------------------- */

    public void sensibilidad(float valor)
    {
        // Asignar objeto Jugador
        Camara = GameObject.FindGameObjectWithTag("MainCamera");

        // Asignar script
        script = Camara.GetComponent<CameraMovement>();

        // Ejecutar funcion para editar valor
        script.AjustarSensibilidad(valor);
    }
}
