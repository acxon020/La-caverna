using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Define la tecla para reiniciar (en este caso, la tecla "R")
    public KeyCode restartKey = KeyCode.R;

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla definida para reiniciar, carga la escena actual
        if (Input.GetKeyDown(restartKey))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Carga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
