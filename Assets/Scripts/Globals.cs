using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Globals : MonoBehaviour
{
    public static Globals instance;
    
    public int diskCountAmount { get; set; } = 3;
    public bool gameIsPaused { get; set; }
    
    public Sound[] sounds;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this.gameObject);
        }

        foreach (Sound s in sounds) {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.clip;
            s.Source.loop = s.loop;
        }
    }

    void Start() {
        Play("BGM");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.Source.Play();
    }
}
