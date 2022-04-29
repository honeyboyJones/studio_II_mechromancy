using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject inverted;

    // public void GoToScene(string sceneName)
    // {
    //     SceneManager.LoadScene(sceneName); //load whatever scene name on the button
    // }

    public void ButtonFunction()
     {
         StartCoroutine(DelaySceneLoad());
         inverted.SetActive(true);
     }
     
     IEnumerator DelaySceneLoad()
     {
         yield return new WaitForSeconds(1.5f); // Wait 1.5 seconds
         SceneManager.LoadScene("zlee prototype_new"); // Change to the ID or Name of the scene to load
     }
}
