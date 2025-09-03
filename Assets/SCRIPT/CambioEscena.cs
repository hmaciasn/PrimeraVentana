using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class CambioEscena : MonoBehaviour
{
    // Método público que podrás asignar al botón
    public void CargarEscena(string personaje)
    {
        SceneManager.LoadScene(personaje);
    }
}

