using UnityEngine;
using UnityEditor;

public class VentanaEditor : EditorWindow
{
    string desplaza = "NULL";
    bool error;
    float posicionZ;
    float posicionX;


    [MenuItem("Window/[Vetana]")]

    // Mostrar Ventana
    public static void ShowWindow()
    {
        GetWindow<VentanaEditor>("Ventana");
    }

    // Codigo de la Vetana
    void OnGUI()
    {
        desplaza = EditorGUILayout.TextField("Desplazamiento Z", desplaza);

        GUILayout.Label("Modificar posicion:", EditorStyles.boldLabel);

        // Boton Modificar
        if (GUILayout.Button("Modificar"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                error = false;
                Transform transform = obj.GetComponent<Transform>();

                if (transform != null)
                {
                    switch (desplaza) {

                        case "X+":
                            posicionX = transform.position.x + 4.5f;
                            posicionZ = transform.position.z;
                            break;

                        case "X-":
                            posicionX = transform.position.x - 4.5f;
                            posicionZ = transform.position.z;
                            break;

                        case "Z+":
                            posicionZ = transform.position.z + 4.5f;
                            posicionX = transform.position.x;
                            break;

                        case "Z-":
                            posicionZ = transform.position.z - 4.5f;
                            posicionX = transform.position.x;
                            break;

                        default:
                            error = true;
                            break;

                    }

                    if (!error)
                    {
                        Vector3 posicion = new Vector3(posicionX, transform.position.y - 3, posicionZ);
                        Vector3 scale = new Vector3(transform.localScale.x, transform.localScale.y + 5, transform.localScale.z);

                        transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

                        transform.position = posicion;
                        transform.localScale = scale;
                    }
                    else
                    {
                        Debug.LogError("ERROR: Formato de texto incorrecto");
                    }

                }
            }
        }

        if (GUILayout.Button("VOLVER"))
        {

            foreach (GameObject obj in Selection.gameObjects)

            {
                Transform transform = obj.GetComponent<Transform>();

                if (transform != null)
                {

                switch (desplaza)
                {

                    case "X+":
                        posicionX = transform.position.x - 4.5f;
                        posicionZ = transform.position.z;
                        break;

                    case "X-":
                        posicionX = transform.position.x + 4.5f;
                        posicionZ = transform.position.z;
                        break;

                    case "Z+":
                        posicionZ = transform.position.z - 4.5f;
                        posicionX = transform.position.x;
                        break;

                    case "Z-":
                        posicionZ = transform.position.z + 4.5f;
                        posicionX = transform.position.x;
                        break;

                    default:
                        error = true;
                        break;
                }

                    Vector3 posicion = new Vector3(posicionX, transform.position.y + 3, posicionZ);
                    Vector3 scale = new Vector3(transform.localScale.x, transform.localScale.y - 5, transform.localScale.z);

                    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

                    transform.position = posicion;
                    transform.localScale = scale;
                }
            }
        }
    }
}
