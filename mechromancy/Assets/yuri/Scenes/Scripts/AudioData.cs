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

    public List<AudioClip> Fectch()
    {
        return aduioSources;
    }
}
