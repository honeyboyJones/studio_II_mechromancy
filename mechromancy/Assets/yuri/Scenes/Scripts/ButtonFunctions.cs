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
    public static event Btn_Clicked OpenLevelMenu;
    public static event Btn_Clicked LevelButtons;
    
    public static event Btn_Clicked On_CreditScreen;

    [Header ("AudioScources DB")]   
    public AudioData audioDB;
    public List<AudioClip> aduioSources;
    public AudioSource clickAudio;
    [Header("UI Staff")]
    public Slider LoadingSlider;
    public Text LoadingText;

    public GameObject MainMenu, PauseMenu, LoadingScreen,CreditScreen, LevelMenu;

    public GameObject DS;
    string curSceneName;

    private void Awake()
    {
        InitGameObject();

        aduioSources = audioDB.Fectch();

        //Start button
        ButtonFunctions.OnClick_StartGame += ClickAudio;
        ButtonFunctions.OnClick_StartGame += HideMainMenu;
        ButtonFunctions.OnClick_StartGame += DestoryDS;
        ButtonFunctions.OnClick_StartGame += ShowLoadingScreen;
        //ButtonFunctions.OnClick_StartGame += ShowDS;

        //pop ou Pause menu
        ButtonFunctions.OnClick_PauseMenu += ClickAudio;
        ButtonFunctions.OnClick_PauseMenu += ShowPasueMenu;
        ButtonFunctions.OnClick_PauseMenu += PauseGame;

        ButtonFunctions.On_CreditScreen += ShowCreditScreen;
        ButtonFunctions.On_CreditScreen += PauseGame;
        //close the Pause Menu
        ButtonFunctions.OnClose_PauseMenu += ClickAudio;
        ButtonFunctions.OnClose_PauseMenu += HidePasueMenu;
        ButtonFunctions.OnClose_PauseMenu += ResumeGame;

        //Back to Main Menu
        ButtonFunctions.backMainMenu += OnClose_PauseMenu;
        ButtonFunctions.backMainMenu += HideCreditScreen;
        ButtonFunctions.backMainMenu += ShowMainMenu;
        ButtonFunctions.backMainMenu += ShowLoadingScreen;
        //ButtonFunctions.backMainMenu += DestoryDS;
        ButtonFunctions.backMainMenu += HideDS;
        //ButtonFunctions.backMainMenu += UnloadAllScenes;

        //Open Level Menu
        ButtonFunctions.OpenLevelMenu += ClickAudio;
        ButtonFunctions.OpenLevelMenu += ShowLevelMenu;

        ButtonFunctions.LevelButtons += ClickAudio;
        ButtonFunctions.LevelButtons += ShowLoadingScreen;
        ButtonFunctions.LevelButtons += DestoryDS;
        ButtonFunctions.LevelButtons += OnClose_PauseMenu;
        ButtonFunctions.LevelButtons += HideLevelMenu;

        DontDestroyOnLoad(this.gameObject);
    }


    private void Start()
    {
        clickAudio.clip = aduioSources[0];
    }
    private void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if(DS==null&&SceneManager.GetActiveScene().name!="MainMenu")
        {
            DS = GameObject.Find("Dialogue Manager");
        }
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
    public void StartGame_Prologue()
    {
        OnClick_StartGame();
        //SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        StartCoroutine(LoadAsync("Prologue"));
    }
    public void StartGame_TraversalLayout()
    {
        OnClick_StartGame();
        //SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        StartCoroutine(LoadAsync("TraversalLayoutNew"));
    }
    public void ReStartGame()
    {
        Debug.Log("Restart Game");
        OnClose_PauseMenu();
        OnClick_StartGame();
        //SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        curSceneName = SceneManager.GetActiveScene().name;
        //UnloadAllScenes();
        StartCoroutine(LoadAsync(curSceneName));
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
        StartCoroutine(LoadAsync("BlackScene"));
    }
    #region Level Menu
    public void B_LevelMenu()
    {
        OpenLevelMenu();
    }
    public void B_LevelPrologue()
    {
        LevelButtons();
        StartCoroutine(LoadAsync("Prologue"));
    }
    public void B_LevelTraversalLayoutNew()
    {
        LevelButtons();
        StartCoroutine(LoadAsync("TraversalLayoutNew"));
    }
    public void B_LevelTutorial()
    {
        LevelButtons();
        StartCoroutine(LoadAsync("Tutorial"));
    }
    public void B_LevelResolution()
    {
        LevelButtons();
        StartCoroutine(LoadAsync("Resolution"));
    }
    public void B_LevelBackToPause()
    {
        ClickAudio();
        HideLevelMenu();
    }
    #endregion

    public void SceneChanger(string sceneName)
    {
        ShowLoadingScreen();
        StartCoroutine(LoadAsync(sceneName));
    }

    public void Fina_ShowCreditScreen()
    {
        ShowCreditScreen();
    }
    #endregion

    #region Audio Thing
    public void ClickAudio()
    {
        clickAudio.Play();
    }
    #endregion
    #region Loading


    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            LoadingSlider.value = operation.progress/0.9f;
            LoadingText.text = (LoadingSlider.value/1).ToString("00"+"%");

            Debug.Log(operation.progress);
            yield return null;
        }
        HideLoadingScreen();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

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

    public void HideLevelMenu()
    {
        LevelMenu.SetActive(false);
    }
    public void ShowLevelMenu()
    {
        LevelMenu.SetActive(true);
        //StartCoroutine(LoadAsync());
    }

    public void ShowCreditScreen()
    {
        CreditScreen.SetActive(true);
    }
    public void HideCreditScreen()
    {
        CreditScreen.SetActive(false);
    }

    public void HideDS()
    {
        if(DS!=null)
        {
            DS.transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
            //DS.SetActive(false);
        }
    }
    public void ShowDS()
    {
        if (DS != null)
        {
            DS.transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        }
    }
    public void DestoryDS()
    {
        if (DS != null)
        {
            Destroy(DS);
        }

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
    void FindDS()
    {
       // GameObject.Fin
    }
    void InitGameObject()
    {
        MainMenu = this.transform.Find("MainMenu").gameObject;
        LoadingScreen = this.transform.Find("LoadingScreen").gameObject;
        PauseMenu = this.transform.Find("PauseMenu").gameObject;
        LevelMenu = this.transform.Find("LevelMenu").gameObject;
        CreditScreen = this.transform.Find("CreditScreen").gameObject;
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
