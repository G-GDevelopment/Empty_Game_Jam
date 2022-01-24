using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance  == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach(Sound sound in sounds)
        {
           sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.PlayOnAwake;
        }
    }


    private void Start()
    {
        PlaySound("Theme");
    }

    public void PlaySound(string p_name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == p_name);
        if(s == null)
        {
            Debug.LogError("Sound: " + p_name + " not found");
            return;
        }

        s.source.Play();


    }

    public void PlayClick()
    {
        PlaySound("Click");
    }
}
