using UnityEngine;
using UnityEngine.UI;
public class EnlaceControlador: MonoBehaviour
{
    void start()
    {

    }

    void update()
    {

    }
    public void Controlador(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
