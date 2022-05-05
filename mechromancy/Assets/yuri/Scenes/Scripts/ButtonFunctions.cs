using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public delegate void Btn_Clicked();
    public static event Btn_Clicked OnClick_StartGame;
    public static event Btn_Clicked OnClick_PauseMenu;
    public static event Btn_Clicked OnClose_PauseMenu;
    public static event Btn_Clicked backMainMenu;

    [Header ("AudioScources DB")]   
    public AudioData audioDB;
    public List<AudioClip> aduioSources;
    public AudioSource clickAudio;
    [Header("UI Staff")]
    public Slider LoadingSlider;
    public Text LoadingText;

    public GameObject MainMenu, PauseMenu, LoadingScreen,CreditScreen;
    public SceneData sceneData;
    public List<string> sceneNames;

    private void Awake()
    {
        InitGameObject();

        aduioSources = audioDB.Fectch();

        //Start button
        ButtonFunctions.OnClick_StartGame += ClickAudio;
        ButtonFunctions.OnClick_StartGame += HideMainMenu;
        ButtonFunctions.OnClick_StartGame += ShowLoadingScreen;

        //pop ou Pause menu
        ButtonFunctions.OnClick_PauseMenu += ClickAudio;
        ButtonFunctions.OnClick_PauseMenu += ShowPasueMenu;
        ButtonFunctions.OnClick_PauseMenu += PauseGame;

        //close the Pause Menu
        ButtonFunctions.OnClose_PauseMenu += ClickAudio;
        ButtonFunctions.OnClose_PauseMenu += HidePasueMenu;
        ButtonFunctions.OnClose_PauseMenu += ResumeGame;

        //Back to Main Menu
        ButtonFunctions.backMainMenu += OnClose_PauseMenu;
        ButtonFunctions.backMainMenu += ShowMainMenu;
        ButtonFunctions.backMainMenu += UnloadAllScenes;


    }


    private void Start()
    {
        clickAudio.clip = aduioSources[0];
    }
    private void Update()
    {
        Debug.Log("TimeScale"+ Time.timeScale);
        if(Input.GetKeyDown(KeyCode.Escape)&& !MainMenu.activeSelf)
        {
            if(!PauseMenu.activeSelf)
            {

                OnClick_PauseMenu();
            }
            else
            {
                OnClose_PauseMenu();
            }
        }
    }

    #region ButtonFunctions
    public void StartGame()
    {
        OnClick_StartGame();
        //SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        StartCoroutine(LoadAsync());
    }
    public void ReStartGame()
    {
        Debug.Log("Restart Game");
        OnClose_PauseMenu();
        OnClick_StartGame();
        //SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        StartCoroutine(LoadAsync());
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        ClickAudio();
        Application.Quit();
    }
    public void BackMainMenu()
    {
        Debug.Log("BackToMenu");
        backMainMenu();
    }
    #endregion

    #region Audio Thing
    public void ClickAudio()
    {
        clickAudio.Play();
    }
    #endregion
    #region Loading


    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNames[1], LoadSceneMode.Additive);

        while(!operation.isDone)
        {
            LoadingSlider.value = operation.progress/0.9f;
            LoadingText.text = (LoadingSlider.value/1).ToString("00"+"%");

            Debug.Log(operation.progress);
            yield return null;
        }
        HideLoadingScreen();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneNames[1]));

    }
    #endregion
    #region UI thing
    public void HideMainMenu()
    {
        MainMenu.SetActive(false);
    }
    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        
    }
    public void HideLoadingScreen()
    {
        LoadingScreen.SetActive(false);
    }
    public void ShowLoadingScreen()
    {
        LoadingScreen.gameObject.SetActive(true);
        //StartCoroutine(LoadAsync());
    }

    public void HidePasueMenu()
    {
        PauseMenu.SetActive(false);
    }
    public void ShowPasueMenu()
    {
        PauseMenu.SetActive(true);
        //StartCoroutine(LoadAsync());
    }

    #endregion

    #region GameSystem

    void UnloadAllScenes()
    {
        Scene [] loadedScene = SceneManager.GetAllScenes();
        for (int i = 0; i < loadedScene.Length; i++)
        {
            Debug.Log(loadedScene[i].name);
            if(loadedScene[i].name!="MainMenu")
            {
                SceneManager.UnloadSceneAsync(loadedScene[i]);
            }
        }
    }
    void InitGameObject()
    {
        MainMenu = this.transform.Find("MainMenu").gameObject;
        LoadingScreen = this.transform.Find("LoadingScreen").gameObject;
        PauseMenu = this.transform.Find("PauseMenu").gameObject;

        sceneNames = sceneData.Fetch();
    }
    public void PauseGame()
    {
        if(Time.timeScale!=0)
        {
            Time.timeScale = 0;
        }

    }
    public void ResumeGame()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
    #endregion
}
