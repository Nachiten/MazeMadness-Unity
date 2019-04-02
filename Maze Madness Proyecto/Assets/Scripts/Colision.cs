using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour {
    
    // Referencia a los scripts de camara y movimiento
    public PlayerMovement movimiento;
    public CameraMovement camara;

    // Referencia al texto
    public Text puntaje;

    // Variables para contar las monedas
    public bool[] coins = new bool[] {false};
    string nombre;
    int cantMonedas;

    // Material (Color) del objetivo
    Material MMaterial;

    // Moneda
    GameObject coin;

    void Start()
    {
        Debug.Log("La cantidad de monedas en esta escena es: " + coins.Length);
    }

    private void OnCollisionEnter(Collision tocar){
        
        // Solo si la escena es un nivel del juego. No ejecuta en tutorial ni selector de niveles
        if (SceneManager.GetActiveScene().buildIndex > 1){

        puntaje.text = cantMonedas.ToString() + "/" + coins.Length + " Monedas Recolectadas";

        for (int i = 1; i<= coins.Length; i++) {

            nombre = "Coin" + (i).ToString();
            // Si toca la moneda y no la tiene ya
            if (tocar.collider.tag == nombre && !coins[i-1])
            {
                // Moneda correspondiente
                coin = GameObject.FindWithTag(nombre);

                // Asigna el material a la variable
                MMaterial = coin.GetComponent<Renderer>().material;

                coin.GetComponent<Animator>().enabled = false;
                
                //Cambia el color
                MMaterial.color = Color.grey;

                // Suma a las variables
                coins[i-1] = true;
                cantMonedas += 1;

                //Cambia el texto de la UI
                puntaje.text = cantMonedas.ToString() + "/" + coins.Length + " Monedas Recolectadas";

                //Muestra por consola
                Debug.Log("Moneda " + cantMonedas + "/" + coins.Length);

            }

        }

        // Comprueba si conseguiste todas las monedas
        if (cantMonedas == coins.Length)
        {
            Debug.Log("Buscamos game manager...");
            FindObjectOfType<GameManager>().EndGame();

            Debug.Log("Desactivamos script movimiento ...");
            movimiento.enabled = false;

            Debug.Log("Desactivamos script camara ...");
            camara.enabled = false;
        }

        if (tocar.collider.tag == "Obstaculo")
            {
                Debug.Log("TOCO PARED ROJA");
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Reiniciar();
            }

        }
    }
}
