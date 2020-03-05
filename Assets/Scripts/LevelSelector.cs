using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    static GameObject levelLoader;
    static Slider slider;
    static Text textoProgreso;
    static Text textoNivel;

    public Texture[] textura;

    public bool DeleteKeys = false;
    static bool flag = true;
    static bool flagCandado = true;

    static GameObject[] candados;

    /* -------------------------------------------------------------------------------- */

    // Muestra que niveles se ganaron al abrir la escena
    void Start()
    {
        if (flag)
        {
            // Aisgnar variables
            levelLoader = GameObject.Find("Panel Carga");
            textoProgreso = GameObject.Find("TextoProgreso").GetComponent<Text>();
            slider = GameObject.Find("Barra Carga").GetComponent<Slider>();

            textoNivel = GameObject.Find("Texto Cargando").GetComponent<Text>();

            flag = false;
        }
        Debug.Log("Los niveles ganados son: " + PlayerPrefs.GetInt("Nivel Ganado"));

        levelLoader.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (flagCandado)
            {
                candados = new GameObject[9];

                for (int i = 2; i < 11; i++)
                {
                    candados[i-2] = GameObject.Find("Nivel" + i.ToString());
                    Debug.Log(candados[i-2]);
                    candados[i - 2].SetActive(true);

                }
                flagCandado = true;
            }

            for (int i = 2; i <= PlayerPrefs.GetInt("Nivel Ganado") + 1; i++)
            { 
                if (i < 11) candados[i - 2].SetActive(false);
            }
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void Nivelx (int x)
    {
        StartCoroutine(cargarAsincronizadamente(x));
        textoNivel.text = "Cargando '" + SceneManager.GetSceneByBuildIndex(x).name + "' ...";
    }

    /* -------------------------------------------------------------------------------- */

    // Iniciar Corutina para cargar nivel en background
    IEnumerator cargarAsincronizadamente(int index)
    {
        // Iniciar carga de escena
        AsyncOperation operacion = SceneManager.LoadSceneAsync(index);

        // Mostrar pantalla de carga
        levelLoader.SetActive(true);

        Debug.Log("Cargando escena: " + index);

        // Mientras la operacion no este terminada
        while (!operacion.isDone)
        {
            // Generar valor entre 0 y 1
            float progress = Mathf.Clamp01(operacion.progress / .9f);
            // Modificar Slider
            slider.value = progress;
            // Modificar texto progreso
            textoProgreso.text = progress * 100f + "%";

            yield return null;
        }
    }

    /* -------------------------------------------------------------------------------- */

    GameObject nivelNoAlcanza;

    void NivelNoAlcanza()
    {
        // Asignar variable
        nivelNoAlcanza = GameObject.Find("NivelNoAlcanza");

        // Animacion Comienza en segundo 0
        nivelNoAlcanza.GetComponent<Animator>().Play("SelectorNivel", -1, 0);
    }

    /* -------------------------------------------------------------------------------- */

    GameObject proximamente;

    public void Proximamente()
    {
        // Asignar variable
        proximamente = GameObject.Find("Proximamente");

        // Animacion Comienza en segundo 0
        proximamente.GetComponent<Animator>().Play("Proximamente", -1, 0);
    }

    /* -------------------------------------------------------------------------------- */

    // Cargar siguiente nivel al terminar la animacion
    public void SiguienteNivel() { Nivelx(SceneManager.GetActiveScene().buildIndex + 1); }

    /* -------------------------------------------------------------------------------- */

    // Ejecutar reinicio al terminar animacion
    public void Restart() { Nivelx(SceneManager.GetActiveScene().buildIndex); }
}