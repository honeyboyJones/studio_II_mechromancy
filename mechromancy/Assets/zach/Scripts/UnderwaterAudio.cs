using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UnderwaterAudio : MonoBehaviour
{
    public static UnderwaterAudio instance;
    public AudioMixerSnapshot defaultSnapshot;
    public AudioMixerSnapshot underwaterSnapshot;

    public string PlayerTag = "Player";

    public int zoneCounter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAudioZone()
    {
        if(zoneCounter > 0)
        {
            underwaterSnapshot.TransitionTo(1f);
        }
        else
        {
            defaultSnapshot.TransitionTo(1f);
        }
    }
}
