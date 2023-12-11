using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuTrigger : MonoBehaviour
{
    // Puedes asignar el nombre de la escena del menú principal desde el Inspector
    public string menuSceneName = "NombreDeTuMenuPrincipal";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador (u otro objeto) ha interactuado con el activador
        if (other.CompareTag("Player"))
        {
            // Llama a la función para cargar la escena del menú principal
            GoToMenu();
        }
    }

    void GoToMenu()
    {
        // Carga la escena del menú principal al interactuar con el activador
        SceneManager.LoadScene(menuSceneName);
    }
}
