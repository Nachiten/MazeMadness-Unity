using UnityEngine;

public class DontDestroyObjetos : MonoBehaviour
{
    //Objetos Menus
    GameObject EscapeMenu;
    GameObject Opciones;
    GameObject PanelSalida;
    //Objetos Musica
    GameObject musica1;
    GameObject musica2;
    GameObject musica3;

    // Flags menus
    static bool flagMenu = true;
    static bool flagOpciones = true;
    static bool flagSalida = true;
    // Flags musica
    static bool flag1 = true;
    static bool flag2 = true;
    static bool flag3 = true;

    /* -------------------------------------------------------------------------------- */

    // Al inicializar el objeto
    void Awake()
    {
        //No destruir si es el primero
        if (flagMenu)
        {
            //EscapeMenu = asignarNombre(EscapeMenu);
            
            EscapeMenu = GameObject.FindGameObjectWithTag("EscapeMenu");
            DontDestroyOnLoad(EscapeMenu);

            flagMenu = false;
        }
        else if (flagOpciones)
        {
            Opciones = GameObject.FindGameObjectWithTag("Opciones");
            DontDestroyOnLoad(Opciones);

            flagOpciones = false;
        }
        else if (flagSalida)
        {
            PanelSalida = GameObject.FindGameObjectWithTag("MensajeSalida");
            DontDestroyOnLoad(PanelSalida);

            flagSalida = false;
        }
        else if (flag1)
        {
            musica1 = GameObject.FindGameObjectWithTag("Music 1");
            DontDestroyOnLoad(musica1);

            flag1 = false;
        }
        else if (flag2)
        {
            musica2 = GameObject.FindGameObjectWithTag("Music 2");
            DontDestroyOnLoad(musica2);

            flag2 = false;
        }
        else if (flag3)
        {
            musica3 = GameObject.FindGameObjectWithTag("Music 3");
            DontDestroyOnLoad(musica3);

            flag3 = false;
        }
        else
        {
            Debug.Log("DESTRUYENDO TODO");
            Destroy(gameObject);
        }

    }
}