using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerPrologue : MonoBehaviour
{
    public CharacterController characterController;
    public AudioData audioData;
    public AudioSource PlayerAudio;
    public AudioClip [] nav_step;
    private void Awake()
    {
        nav_step = audioData.Fectch_nav_step();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(characterController.velocity.magnitude);
        if(characterController.velocity.magnitude> 0.5&& characterController.isGrounded)
        {
            
            if (!PlayerAudio.isPlaying)
            {
                PlayerAudio.PlayOneShot(nav_step[(int)Random.Range(1, 4)]);
            }

        }
        else
        {
            if(!PlayerAudio.isPlaying)
            {

                PlayerAudio.Stop();
            }
        }
    }
}
