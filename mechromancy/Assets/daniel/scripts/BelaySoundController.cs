using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelaySoundController : MonoBehaviour
{
    public List<AudioClip> BelaySounds;
    [Range(0,1)]
    public float PrepareVolume;
    [Range(0, 1)]
    public float SaveVolume;
    [Range(0, 1)]
    public float SaveErrorVolume;
    [Range(0, 1)]
    public float LoadVolume;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        EventManager.RegisterListener("prepare", PrepareSound);
        EventManager.RegisterListener("save", SaveSound);
        EventManager.RegisterListener("savefailed", SaveErrorSound);
        EventManager.RegisterListener("load", LoadSound);
        //Debug.Log(audio.gameObject);
    }

    void PrepareSound() 
    {
        audio.loop = true;
        audio.clip = BelaySounds[0];
        audio.volume = PrepareVolume;
        audio.Play();
    }

    void SaveSound() 
    {
        audio.loop = false;
        audio.clip = BelaySounds[1];
        audio.volume = SaveVolume;
        audio.Play();
    }
    

    void SaveErrorSound() 
    {
        audio.Pause();
        audio.loop = false;
        audio.clip = BelaySounds[2];
        audio.volume = SaveErrorVolume;
        audio.Play();
    }

    void LoadSound() 
    {
       
        audio.clip = BelaySounds[3];
        audio.volume = LoadVolume;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventManager.UnregisterListener("prepare", PrepareSound);
        EventManager.UnregisterListener("save", SaveSound);
        EventManager.UnregisterListener("savefailed", SaveErrorSound);
        EventManager.UnregisterListener("load", LoadSound);
    }
}
