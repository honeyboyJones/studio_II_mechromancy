using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="AudioSourceDB" ,menuName = "Create Audio Sources")]
public class AudioData : ScriptableObject
{
    public List<AudioClip> aduioSources = new List<AudioClip>();
    /*    //Mech
        public AudioClip Step;
        public AudioClip Jump;
        public AudioClip DJump;
        //UI
        public AudioClip Click;*/
    public AudioClip Walk,Jump,DJump,Land,Air,Sprint;

    public AudioClip[] nav_step;

    public List<AudioClip> Fectch()
    {
        return aduioSources;
    }

    public AudioClip FectchAudio_Walk()
    {
        return Walk;
    }
    public AudioClip FectchAudio_Jump()
    {
        return Jump;
    }
    public AudioClip FectchAudio_DJump()
    {
        return DJump;
    }
    public AudioClip FectchAudio_Land()
    {
        return Land;
    }
    public AudioClip FectchAudio_Air()
    {
        return Air;
    }
    public AudioClip FectchAudio_Sprint()
    {
        return Sprint;
    }
    public AudioClip[] Fectch_nav_step()
    {
        return nav_step;
    }
}
