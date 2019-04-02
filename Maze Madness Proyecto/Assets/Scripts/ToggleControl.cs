using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControl : MonoBehaviour
{
    // Objectos toggles
    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject toggle3;

    bool flag = true;

    /* -------------------------------------------------------------------------------- */

    void Start()
    {
        if (flag)
        {
            switch (PlayerPrefs.GetInt("DefaultSong"))
            {
                case 1: {
                        cambiarValor1(true);
                        break;
                }
                case 2: {
                        cambiarValor2(true);
                        break;
                }
                case 3: {
                        cambiarValor3(true);
                        break;
                }
            }
            flag = false;
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void cambiarValor1(bool valor) {

        if (valor)
        {
            asignarValor(1);

            toggle2.SetActive(false);
            toggle3.SetActive(false);
        }
        else
        {
            asignarValor(0);

            toggle2.SetActive(true);
            toggle3.SetActive(true);
        }


    }

    /* -------------------------------------------------------------------------------- */

    public void cambiarValor2(bool valor)
    {
        if (valor)
        {
            asignarValor(2);

            toggle1.SetActive(false);
            toggle3.SetActive(false);
        }
        else
        {
            asignarValor(0);

            toggle1.SetActive(true);
            toggle3.SetActive(true);
        }
    }

    /* -------------------------------------------------------------------------------- */

    public void cambiarValor3(bool valor)
    {
        if (valor)
        {
            asignarValor(3);

            toggle1.SetActive(false);
            toggle2.SetActive(false);
        }
        else
        {
            asignarValor(0);

            toggle1.SetActive(true);
            toggle2.SetActive(true);
        }
    }

    /* -------------------------------------------------------------------------------- */

    void asignarValor(int x) {
        PlayerPrefs.SetInt("DefaultSong", x);
    }
}

