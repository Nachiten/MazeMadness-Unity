using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    public Text nivelNoAlcanza;
    public GameObject proximamente;

    /* -------------------------------------------------------------------------------- */

    // Muestra que niveles se ganaron al abrir la escena
    private void Start()
    {
    Debug.Log("Los niveles ganados son: " + PlayerPrefs.GetInt("Nivel Ganado"));
    }

    /* -------------------------------------------------------------------------------- */

    public void Nivelx (int x)
    {
        string NombreNivel;

        if (x == 10) { // Si el nivel es 10 no se pone 0
            NombreNivel = "Nivel" + x;
        } else { // Si es 1-9 se pone un 0
            NombreNivel = "Nivel0" + x;
        }
        
        if (x <= 5)
        {
            // Si Nivel anterior ganado, entra al nivel
            if (PlayerPrefs.GetInt("Nivel Ganado") >= x-1)
            {
                SceneManager.LoadScene(NombreNivel);
            }
            else // Si no gano, muestra texto
            {
                NivelNoAlcanza();
            }
        }
        else
        {
            // Niveles 6-10 todavia no terminados
            Proximamente();
        }
    }

    /* -------------------------------------------------------------------------------- */

    void NivelNoAlcanza()
    {
        // Se activa el texto
        nivelNoAlcanza.enabled = true;
        // Animacion Comienza en segundo 0
        gameObject.GetComponent<Animator>().Play("SelectorNivel", -1, 0);
    }

    /* -------------------------------------------------------------------------------- */

    public void Proximamente()
    {
        // Se activa el texto
        proximamente.GetComponent<Text>().enabled = true;
        // Animacion Comienza en segundo 0
        proximamente.GetComponent<Animator>().Play("Proximamente", -1, 0);
    }

    /* -------------------------------------------------------------------------------- */

    // Cargar siguiente nivel al terminar la animacion
    public void SiguienteNivel()
    {
        Debug.Log("Cargando siguiente nivel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /* -------------------------------------------------------------------------------- */

    // Ejecutar reinicio al terminar animacion
    public void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
