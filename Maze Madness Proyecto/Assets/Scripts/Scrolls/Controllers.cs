using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Controllers : MonoBehaviour
{
    /* --------------------------- Volumen --------------------------- */

    public AudioMixer mixer;
    GameObject numeroVolumen;
    Text texto;

    public void SetLevel(float valorSlider)
    {
        numeroVolumen = GameObject.FindGameObjectWithTag("Numero Volumen");

        texto = numeroVolumen.GetComponent<Text>();

        texto.text = (valorSlider * 100).ToString("F2");

        valorSlider = valorSlider * 0.9999f + 0.0001f;

        mixer.SetFloat("Volume", Mathf.Log10 (valorSlider) * 20);
    }

    /* --------------------------- Velocidad --------------------------- */

    public void velocidad(float valor) { GameObject.FindGameObjectWithTag("Jugador").GetComponent<PlayerMovement>().AjustarVelocidad(valor); }

    /* --------------------------- Sensibilidad --------------------------- */

    public void sensibilidad(float valor) { GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().AjustarSensibilidad(valor); }
}
