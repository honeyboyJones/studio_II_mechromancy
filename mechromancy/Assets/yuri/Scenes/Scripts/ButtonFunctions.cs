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

    [Header ("AudioScources DB")]   
    public AudioData audioDB;
    public List<AudioClip> aduioSources;
    public AudioSource clickAudio;
    [Header("UI Staff")]
    public Slider LoadingSlider;
    public Text LoadingText;

    private void Awake()
    {
        aduioSources = audioDB.Fectch();

        //Start button
        ButtonFunctions.OnClick_StartGame += ClickAudio;
        ButtonFunctions.OnClick_StartGame += HideMainMenu;
        ButtonFunctions.OnClick_StartGame += HidePasueMenu;
        ButtonFunctions.OnClick_StartGame += ShowLoadingScreen;

        //pop ou Pause menu
        ButtonFunctions.OnClick_PauseMenu += ClickAudio;
        ButtonFunctions.OnClick_PauseMenu += ShowPasueMenu;
        ButtonFunctions.OnClick_PauseMenu += PauseGame;

        //close the Pause Menu
        ButtonFunctions.OnClose_PauseMenu += ClickAudio;
        ButtonFunctions.OnClose_PauseMenu += HidePasueMenu;
        ButtonFunctions.OnClose_PauseMenu += ResumeGame;

    }


    private void Start()
    {
        clickAudio.clip = aduioSources[0];
    }
    private void Update()
    {
        Debug.Log("TimeScale"+ Time.timeScale);
        if(Input.GetKey(KeyCode.Escape)&& !this.transform.Find("MainMenu").gameObject.activeSelf)
        {
            if(!this.transform.Find("PauseMenu").gameObject.activeSelf)
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
    public void Quit()
    {
        OnClick_StartGame();
        Application.Quit();
    }
    public void BackMainMenu()
    {
        OnClick_StartGame();
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
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);

        while(!operation.isDone)
        {
            LoadingSlider.value = operation.progress/0.9f;
            LoadingText.text = (LoadingSlider.value/1).ToString("00"+"%");

            Debug.Log(operation.progress);
            yield return null;
        }
        HideLoadingScreen();

    }
    #endregion
    #region UI thing
    public void HideMainMenu()
    {
        this.transform.Find("MainMenu").gameObject.SetActive(false);
    }
    public void ShowMainMenu()
    {
        this.transform.Find("MainMenu").gameObject.SetActive(false);
        
    }
    public void HideLoadingScreen()
    {
        this.transform.Find("LoadingScreen").gameObject.SetActive(false);
    }
    public void ShowLoadingScreen()
    {
        this.transform.Find("LoadingScreen").gameObject.SetActive(true);
        //StartCoroutine(LoadAsync());
    }

    public void HidePasueMenu()
    {
        this.transform.Find("PauseMenu").gameObject.SetActive(false);
    }
    public void ShowPasueMenu()
    {
        this.transform.Find("PauseMenu").gameObject.SetActive(true);
        //StartCoroutine(LoadAsync());
    }

    #endregion

    #region GameSystem
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
            //Time.timeScale = 1;
        }
    }
    #endregion
}
