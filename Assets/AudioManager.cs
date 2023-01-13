using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {    
    public static AudioManager Instance;

    public Sound[] sfxSounds;
    public AudioSource sfxSource;

    public void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string name) {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null) {
            Debug.Log("Sound not found");
        } else {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
