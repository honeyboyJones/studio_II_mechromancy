using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walk,flying;

    public enum Mode
    {
        Walking,Running,Flying
    }

    public Mode mode = Mode.Flying;
    private void Awake()
    {
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mode = Mode.Walking;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                mode = Mode.Running;
            }
        }
        else
        {

            mode = Mode.Flying;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            mode = Mode.Flying;
        }

        if (mode == Mode.Walking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
        }

            //
    }
}
