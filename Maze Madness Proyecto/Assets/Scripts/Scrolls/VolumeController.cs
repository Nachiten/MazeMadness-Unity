using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    GameObject numeroVolumen;
    Text texto;

    /* -------------------------------------------------------------------------------- */

    public void SetLevel(float valorSlider)
    {
        numeroVolumen = GameObject.FindGameObjectWithTag("Numero Volumen");

        texto = numeroVolumen.GetComponent<Text>();

        texto.text = (valorSlider * 100).ToString("F2");

        valorSlider = valorSlider * 0.9999f + 0.0001f;

        mixer.SetFloat("Volume", Mathf.Log10 (valorSlider) * 20);
    }
}
