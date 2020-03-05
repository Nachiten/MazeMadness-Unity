using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ModificarBoton : MonoBehaviour
{
    public Text texto;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            texto.text = "Comenzar";
        }
        else
        {
            texto.text = "Continuar";
        }
    }
}
