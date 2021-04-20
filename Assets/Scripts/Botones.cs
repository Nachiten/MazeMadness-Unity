using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {
    static GameObject menu;
    static GameObject opciones;
           GameObject texto;
   // static GameObject botonComenzar;
    static GameObject panelSalida;

    static bool flag = true;

    //

    void Start()
    {
        Debug.Log("CARGO!");

        if (flag) {
            menu = GameObject.Find("Menu");
            opciones = GameObject.Find("Opciones");
            panelSalida = GameObject.FindGameObjectWithTag("MensajeSalida");

            flag = false;
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void Comenzar_Continuar ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) cargarNivel(3);

        else GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().manejarMenu(false);
    }

    /* -------------------------------------------------------------------------------- */

    public void Salir() {

        Debug.Log("Desactivando menus");
        menu.SetActive(false);
        opciones.SetActive(false);
        /*
        // Ocultar dexto del inicio si estamos en escena Inicio
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            texto = GameObject.FindGameObjectWithTag("TextoInicio");
            Debug.Log("Desactivando texto");
            texto.SetActive(false);
        }*/

        // Activar panel salida
        panelSalida.SetActive(true);
    }

    /* -------------------------------------------------------------------------------- */

    public void SalirDelJuego() { Application.Quit(); }

    /* -------------------------------------------------------------------------------- */

    public void cargarNivel(int nivel) { FindObjectOfType<LevelSelector>().Nivelx(nivel); }

    /* -------------------------------------------------------------------------------- */

    public void Opciones(bool booleano)
    {
        if (booleano) { Debug.Log("Abriendo Opciones"); }
        else {  Debug.Log("Cerrando Opciones"); }

        menu.SetActive(!booleano);
        opciones.SetActive(booleano);
    }
}
