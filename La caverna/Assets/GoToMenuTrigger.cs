using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuTrigger : MonoBehaviour
{
    // Puedes asignar el nombre de la escena del men� principal desde el Inspector
    public string menuSceneName = "NombreDeTuMenuPrincipal";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador (u otro objeto) ha interactuado con el activador
        if (other.CompareTag("Player"))
        {
            // Llama a la funci�n para cargar la escena del men� principal
            GoToMenu();
        }
    }

    void GoToMenu()
    {
        // Carga la escena del men� principal al interactuar con el activador
        SceneManager.LoadScene(menuSceneName);
    }
}
