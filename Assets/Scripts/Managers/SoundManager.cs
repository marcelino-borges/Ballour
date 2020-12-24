using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [HideInInspector]
    public AudioSource audioSource;
    public float currentVolume = 1f;

    public AudioClip buttonClickSfx;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySound2D(AudioClip audio)
    {
        audioSource.PlayOneShot(audio, currentVolume);
    }

    public void PlayButtonSfx()    
    {
        if(buttonClickSfx != null)
            PlaySound2D(buttonClickSfx);
    }

}
