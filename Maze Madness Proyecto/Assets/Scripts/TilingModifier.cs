using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingModifier : MonoBehaviour
{
    int contador;

    GameObject piso;

    // Start is called before the first frame update
    void Start()
    {
        contador = 1;

        while (GameObject.Find("Piso " + contador.ToString())) {

            piso = GameObject.Find("Piso " + contador.ToString());

            Transform transform = piso.GetComponent<Transform>();
            Renderer textura = piso.GetComponent<Renderer>();

            // Ajustar "Tiling" de textura
            textura.material.mainTextureScale = new Vector2(transform.localScale.x / 10, transform.localScale.z / 10);

            Debug.Log("PISO: " + piso + " | Transform: " + transform + " | Textura: " + textura);

            contador++;
        }
    }

}
