using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ColisionPC : MonoBehaviour {
    /*

    // Referencia a los scripts de camara y movimiento

    // Referencia al texto
    public Text puntaje;
    public GameObject GanoPC;

    // Variables para contar las monedas
    public bool[] coins = new bool[] { false };
    string nombre;
    int cantMonedas;

    // Material (Color) del objetivo
    Material MMaterial;

    // Moneda
    GameObject coin;


    private void OnCollisionEnter(Collision tocar)
    {

        // Solo si la escena es un nivel del juego. No inicio ni tutorial ni selector de niveles
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {

            puntaje.text = cantMonedas.ToString() + "/" + coins.Length + " Monedas Recolectadas por la PC";

            // Testing
            Debug.Log("Script PC Funcionando " + coins.Length);

            for (int i = 1; i <= coins.Length; i++)
            {

                nombre = "Coin" + (i).ToString();
                // Si toca la moneda y no la tiene ya
                if (tocar.collider.tag == nombre && !coins[i - 1])
                {
                    // Moneda correspondiente
                    coin = GameObject.FindWithTag(nombre);

                    // Suma a las variables
                    coins[i - 1] = true;
                    cantMonedas += 1;

                    //Cambia el texto de la UI
                    puntaje.text = cantMonedas.ToString() + "/" + coins.Length + " Monedas Recolectadas por la PC";

                    //Muestra por consola
                    Debug.Log("Moneda de PC " + cantMonedas + "/" + coins.Length);

                }

            }

            // Comprueba si conseguiste todas las monedas
            if (cantMonedas == coins.Length)
            {
                Debug.Log("Ha ganado la PC");
                GanoPC.SetActive(true);

            }

        }
    }*/
}
