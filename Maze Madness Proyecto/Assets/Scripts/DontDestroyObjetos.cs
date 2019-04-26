using UnityEngine;

public class DontDestroyObjetos : MonoBehaviour
{
    //Objeto Menus
    GameObject EscapeMenu;
    //Objeto Musica
    GameObject music;
   
    // Flag menus
    static bool flagMenu = true;
    // Flag musica
    static bool flag1 = true;

    /* -------------------------------------------------------------------------------- */

    // Al inicializar el objeto
    void Awake()
    {
        //No destruir si es el primero
        if (flagMenu)
        {
            EscapeMenu = GameObject.Find("Menus [DontDestroy]");
            DontDestroyOnLoad(EscapeMenu);

            flagMenu = false;
        }
        else if (flag1)
        {
            music = GameObject.Find("Music");
            DontDestroyOnLoad(music);

            flag1 = false;
        }
        else
        {
            // Destruir si ya existe uno
            Debug.Log("DESTRUYENDO TODO");
            Destroy(gameObject);
        }

    }
}