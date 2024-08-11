using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance of the AudioManager
    public static AudioManager instance;

    // Array of SoundManager objects to hold music sounds
    public SoundManager[] musicSound;
    // AudioSource component to play the music
    public AudioSource musicSource;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            // Prevent this object from being destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate instances
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Play background music at the start
        PlayeMusic("Background Sound");
    }

    // Method to play music by name
    public void PlayeMusic(string name)
    {
        // Find the SoundManager object with the specified name
        SoundManager sound = Array.Find(musicSound, x => x.name == name);
        if (sound == null)
        {
            // Log an error if the music is not found
            Debug.Log("Music not found");
        }
        else
        {
            // Set the AudioSource clip to the found sound and play it
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    // Method to toggle music on and off
    public void ToggleMusic()
    {
        // Mute or unmute the music
        musicSource.mute = !musicSource.mute;
    }

    // Method to adjust the music volume
    public void MusicVolume(float volume)
    {
        // Set the volume of the AudioSource
        musicSource.volume = volume;
    }
}
