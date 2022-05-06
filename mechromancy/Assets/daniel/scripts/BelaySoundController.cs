using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelaySoundController : MonoBehaviour
{
    public List<AudioClip> BelaySounds;
    [Range(0,1)]
    public float PrepareVolume=1;
    [Range(0, 1)]
    public float SaveVolume=1;
    [Range(0, 1)]
    public float SaveErrorVolume=1;
    [Range(0, 1)]
    public float LoadVolume=1;
    [Range(0, 1)]
    public float CancleVolume =1;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        EventManager.RegisterListener("prepare", PrepareSound);
        EventManager.RegisterListener("save", SaveSound);
        EventManager.RegisterListener("savefailed", SaveErrorSound);
        EventManager.RegisterListener("load", LoadSound);
        EventManager.RegisterListener("cancle", CancleSound);
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

    void CancleSound() 
    {
        audio.Pause();
        audio.loop = false;
        audio.clip = BelaySounds[4];
        audio.volume = CancleVolume;
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
        EventManager.UnregisterListener("cancle", CancleSound);
    }
}
