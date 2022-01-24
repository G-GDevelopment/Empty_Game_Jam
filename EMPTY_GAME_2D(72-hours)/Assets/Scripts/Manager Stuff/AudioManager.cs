using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEditor.Audio;
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
        PlaySound("Theme", true);
    }

    public void PlaySound(string p_name, bool p_waitForSourceToFinish)
    {
        Sound s = Array.Find(sounds, sound => sound.name == p_name);
        if(s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
            return;
        }
        if(!s.source.isPlaying && p_waitForSourceToFinish || !p_waitForSourceToFinish)
        {
            s.source.Play();

        }
    }

    public void PickRandomSound(string p_name1, string p_name2, string p_name3, string p_name4)
    {
        int index = Mathf.RoundToInt(Random.Range(1, 4));

        if(index == 1)
        {
            PlaySound(p_name1, false);
        }else if( index == 2)
        {
            PlaySound(p_name2, false);
        }else if( index == 3)
        {
            PlaySound(p_name3, false);
        }else
        {
            PlaySound(p_name4, true);
        }
    }

    public void PickRandomSound(string p_name1, string p_name2, string p_name3)
    {
        int index = Mathf.RoundToInt(Random.Range(1, 3));

        if (index == 1)
        {
            PlaySound(p_name1, true);
        }
        else if (index == 2)
        {
            PlaySound(p_name2, true);
        }
        else
        {
            PlaySound(p_name3, true);
        }

    }
    public void PickRandomSound(string p_name1, string p_name2)
    {
        int index = Mathf.RoundToInt(Random.Range(1, 3));

        if (index == 1)
        {
            PlaySound(p_name1, true);
        }
        else
        {
            PlaySound(p_name2, true);
        }


    }

    public void PlayClick()
    {
        PlaySound("Click", false);
    }
}
