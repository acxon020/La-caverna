using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
 public void play()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 }
    
public void Exit()
{
Debug.Log("Salir");
Application.Quit();
}

}

