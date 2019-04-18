using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    static bool flagOpcionesMenu = true;
           bool flag = false;

    public bool AllLevelsAccess;
    public bool RestartVariable;

    static GameObject panelSalida;
    static GameObject menu;
    static GameObject opciones;
           GameObject pantallaGano;
           GameObject reinicioNivel;

    /* -------------------------------------------------------------------------------- */

    // Se llama al cargarse la escena por unica vez
    void Start()
    {

        if (RestartVariable)
        {
            // Elimina la variable de Nivel Ganado [Guardada al cerrar]
            PlayerPrefs.DeleteKey("Nivel Ganado");
            Debug.LogError("ELIMINANDO VARIABLE NIVEL GUARDADO !!");
        }
        else if (AllLevelsAccess)
        {
            // Permite acceso a todos los niveles
            PlayerPrefs.SetInt("Nivel Ganado", 10);
            Debug.LogError("PERMITIENDO INGRESO A CUALQUIER NIVEL !!");
        }
        else
        {
            Debug.LogWarning("No se configuro ninguna variable especial");
        }

        Debug.LogWarning("Variable niveles guardados: " + PlayerPrefs.GetInt("Nivel Ganado"));

        if (flagOpcionesMenu)
        {
            opciones = GameObject.FindGameObjectWithTag("Opciones");
            menu = GameObject.FindGameObjectWithTag("EscapeMenu");
            panelSalida = GameObject.FindGameObjectWithTag("MensajeSalida");

            flagOpcionesMenu = false;
        }

        switch (SceneManager.GetActiveScene().buildIndex) { 

            // Si estamos en inicio
            case 0: {
                panelSalida.SetActive(false);
                menu.SetActive(true);
                break;
                }

            // Si estamos en LevelSelector
            case 1: {
                 // Desactivar menu sin ocultar y bloquear mouse
                 menu.SetActive(false);

                 // Modificar flag para marcar menu cerrado
                 flag = true;

                 break;
                }

            // Si estamos en tutorial o cualquier nivel
            default: {
                // Desactivar menu, ocultar y blockear mouse
                flag = manejarMenu(flag);

                // Declarar la pantalla gano
                pantallaGano = GameObject.FindGameObjectWithTag("PantallaGano");

                // Desactivar pantalla gano
                pantallaGano.SetActive(false);

                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    // Declarar la pantalla reinicio nivel
                    reinicioNivel = GameObject.FindGameObjectWithTag("ReinicioNivel");

                    reinicioNivel.SetActive(false);
                }           
                break;
            }
        }

        // Desactivar opciones siempre
        opciones.SetActive(false);
    }

    /* -------------------------------------------------------------------------------- */

    // Cuando Ganas el nivel
    public void EndGame()
    {
        Debug.Log("Nivel terminado prro.... activando animacion");
        //  pantallaGano = GameObject.FindGameObjectWithTag("Pantalla Gano");

        // Darle valor a la variable que acumula niveles ganados [Guardada al cerrar]
        if (PlayerPrefs.GetInt("Nivel Ganado") < SceneManager.GetActiveScene().buildIndex - 2)

            PlayerPrefs.SetInt("Nivel Ganado", SceneManager.GetActiveScene().buildIndex - 2);

        Debug.Log("El nivel ganado actualmente es: " + PlayerPrefs.GetInt("Nivel Ganado"));

        // Activar animacion
        pantallaGano.SetActive(true);
    }

    /* -------------------------------------------------------------------------------- */

    // Comenzar animacion de reinicio
    public void Reiniciar() {
        Debug.Log("ACTIVANDO ANIMACION RENICIIO");
        reinicioNivel.SetActive(true); } 
    
    /* -------------------------------------------------------------------------------- */

    // Se llama una vez por fotograma
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex > 1 && Input.GetKeyDown("escape"))
        {
            // SE ABRE MENU
            if (flag)
            {
                Debug.Log("Menu Abierto");
                flag = manejarMenu(flag);
            }
            // SE CIERRA MENU
            else if (!flag)
            {
                Debug.Log("Menu Cerrado");
                flag = manejarMenu(flag);
                opciones.SetActive(false);
            }
        }
    }

    /* -------------------------------------------------------------------------------- */

    public bool manejarMenu(bool cambio)
    {
        Cursor.visible = cambio;
        // Si el menu fue abierto
        if (cambio == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        // Si el menu fue cerrado
        else {
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        GameObject.FindGameObjectWithTag("Jugador").GetComponent<PlayerMovement>().enabled = !cambio;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().enabled = !cambio;
        GameObject.FindGameObjectWithTag("Jugador").GetComponent<Rigidbody>().isKinematic = cambio;

        menu.SetActive(cambio);
        cambio = !cambio;
        return cambio;
    }

    /* -------------------------------------------------------------------------------- */

    public void cerrarMenu() { flag = manejarMenu(flag); }

    /* -------------------------------------------------------------------------------- */

    public void ExitGame()
    {
        Debug.Log("Cerrando juego !!!");
        Application.Quit();
    }
}