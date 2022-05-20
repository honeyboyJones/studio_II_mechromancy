using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//Tori's Scene Changer Testing Script

public class SceneChangerTest : MonoBehaviour
{
    public string sceneName; //set scene name to change to in Inspector

    // Start is called before the first frame update
    public ButtonFunctions buttonFunctions;
    private void Awake()
    {
        buttonFunctions = GameObject.Find("MainMenuCanvas").GetComponent<ButtonFunctions>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        if (sceneName == "MainMenu")
        {
            buttonFunctions.Fina_ShowCreditScreen();
            buttonFunctions.HideDS();
            //OnLockCamera = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            //buttonFunctions.ShowMainMenu();
            //buttonFunctions.SceneChanger("BlackScene");
        }
        else
        {
            buttonFunctions.SceneChanger(sceneName);
        }

    }
}
