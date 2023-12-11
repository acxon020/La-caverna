using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
 public void play()
 {
    SceneManager.LoadScene("SampleScene");

 }
    
public void Exit()
{
Debug.Log("Salir");
Application.Quit();
}

}

