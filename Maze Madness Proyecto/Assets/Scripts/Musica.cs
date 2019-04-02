using UnityEngine;

public class Musica : MonoBehaviour
{
    //Objetos Musica
    GameObject musica1;
    GameObject musica2;
    GameObject musica3;

    // Componentes de audio
    AudioSource sonido1;
    AudioSource sonido2;
    AudioSource sonido3;

    static bool flag = true;

    /* -------------------------------------------------------------------------------- */

    // Al inicializar el objeto
    void Awake()
    {
        //Asignar objetos
        musica1 = GameObject.FindGameObjectWithTag("Music 1");
        musica2 = GameObject.FindGameObjectWithTag("Music 2");
        musica3 = GameObject.FindGameObjectWithTag("Music 3");

        //Asignar componentes de audio
        sonido1 = musica1.GetComponent<AudioSource>();
        sonido2 = musica2.GetComponent<AudioSource>();
        sonido3 = musica3.GetComponent<AudioSource>();

        //Obtener variable "DefaultSong" para iniciar cancion por defecto
        if (flag) { 
            switch (PlayerPrefs.GetInt("DefaultSong"))
            {
                case 1: {
                        sonido1.Play();
                        break;
                }
                case 2: {
                        sonido2.Play();
                        break;
                }
                case 3: {
                        sonido3.Play();
                        break;
                }
            }
            flag = false;
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void IniciarMusica1()
    {
        sonido1.Play();
        sonido2.Stop();
        sonido3.Stop();
    }

    /* -------------------------------------------------------------------------------- */

    public void IniciarMusica2()
    {
        sonido1.Stop();
        sonido2.Play();
        sonido3.Stop();
    }

    /* -------------------------------------------------------------------------------- */

    public void InisicarMusica3()
    {
        sonido1.Stop();
        sonido2.Stop();
        sonido3.Play();
    }

    /* -------------------------------------------------------------------------------- */

    public void DetenerMusica()
    {
        sonido1.Stop();
        sonido2.Stop();
        sonido3.Stop();
    }

}