using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {
    public GameObject menu;
    public GameObject opciones;
           GameObject texto;
    static GameObject botonComenzar;
    static GameObject panelSalida;

    static bool flag = true;

    void Start()
    {
        if (flag) { 
        panelSalida = GameObject.FindGameObjectWithTag("MensajeSalida");
        flag = false;
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void Comenzar_Continuar ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene("Nivel01");
        }
        else
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().manejarMenu(false);
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void IniciarTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /* -------------------------------------------------------------------------------- */

    public void Inicio() { SceneManager.LoadScene("Inicio"); }

    /* -------------------------------------------------------------------------------- */

    public void Salir() {

        Debug.Log("Desactivando menus");
        menu.SetActive(false);
        opciones.SetActive(false);

        // Ocultar dexto del inicio si estamos en escena Inicio
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            texto = GameObject.FindGameObjectWithTag("TextoInicio");
            Debug.Log("Desactivando texto");
            texto.SetActive(false);
        }

        // Activar panel salida
        panelSalida.SetActive(true);
    }

    /* -------------------------------------------------------------------------------- */

    public void SalirDelJuego() { Application.Quit(); }

    /* -------------------------------------------------------------------------------- */

    public void LevelSelector()
    {
        //activarMeus();
        SceneManager.LoadScene("LevelSelector");
    }

    /* -------------------------------------------------------------------------------- */

    public void Opciones(bool booleano)
    {
        if (booleano) { Debug.Log("Abriendo Opciones"); }
        else {  Debug.Log("Cerrando Opciones"); }

        menu.SetActive(!booleano);
        opciones.SetActive(booleano);
    }
}
