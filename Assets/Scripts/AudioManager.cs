using UnityEngine;
using System;
using UnityEngine.Audio; 

public class AudioManager : MonoBehaviour
{
    public AudioSystem[] sounds;
    public static AudioManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (AudioSystem s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
        }
    }

    public void Play (string name)
    {
        AudioSystem s = Array.Find(sounds, AudioSystem => AudioSystem.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + ".exe Not found!"); 
            return;
        }
        s.source.Play();
    }
   
}
