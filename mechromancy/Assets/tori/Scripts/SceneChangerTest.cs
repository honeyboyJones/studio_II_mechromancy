using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//Tori's Scene Changer Testing Script

public class SceneChangerTest : MonoBehaviour
{
    public string sceneName; //set scene name to change to in Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
