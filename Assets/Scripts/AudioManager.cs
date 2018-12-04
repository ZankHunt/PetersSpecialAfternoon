using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Audio[] audios;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }  
    }

    public void Play(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
            return;
        a.source.mute = false;
        a.source.Play();
    }

    public void Stop(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
            return;
        a.source.mute = true;
        a.source.Stop();
    }
}
