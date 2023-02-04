using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public Sound[] musicSound, sfxSound, aiSound;
    public AudioSource musicSourc, sfsSource, aiSource;

    public bool BGMisMute { get; set; }
    public bool SFXisMute { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        PlayMusic("Theme");
        

        BGMisMute = false;
        SFXisMute = false;
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSourc.clip = s.clip;
            musicSourc.Play();
        }
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSourc.clip = s.clip;
            musicSourc.Stop();
        }

    }

    public void PlayAISound(string name)
    {
        Sound s = Array.Find(aiSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            aiSource.PlayOneShot(s.clip);
        }

    }

    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            sfsSource.PlayOneShot(s.clip);
        }
    }

    public void TogleMusic()
    {
        musicSourc.mute = !musicSourc.mute;

    }
    public void TogleSFX(){
        sfsSource.mute = !sfsSource.mute ;

    }

    public void MusicVolume(float volume)
    {
        musicSourc.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfsSource.volume = volume;
    }
}
