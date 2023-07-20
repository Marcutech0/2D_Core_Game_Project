using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MMButtons : MonoBehaviour
{
  
public void playGame()
    {
        SceneManager.LoadScene("2D Game Project");

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
   
}
