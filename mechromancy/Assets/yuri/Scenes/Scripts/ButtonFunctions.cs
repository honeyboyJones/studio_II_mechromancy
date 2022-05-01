using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame()
    {
       // SceneManager.LoadScene("StartScene",);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
