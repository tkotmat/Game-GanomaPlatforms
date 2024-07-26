using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{
    public AudioClip[] backgroundMusicTracks;
    [Range(0.001f, 0.010f)] public float musicVolume = 0.010f;

    private AudioSource musicSrc;

    void Awake()
    {
        musicSrc = gameObject.AddComponent<AudioSource>();
        musicSrc.loop = true;
        musicSrc.playOnAwake = false;
    }

    void Start()
    {
        if (backgroundMusicTracks.Length > 0)
        {
            PlayRandomBackgroundMusic();
        }
        // Load saved music volume
        musicVolume = PlayerPrefs.GetFloat("musicVolume", musicVolume);
        musicSrc.volume = musicVolume;
    }

    public void PlayRandomBackgroundMusic()
    {
        if (backgroundMusicTracks.Length == 0) return;

        int randomIndex = Random.Range(0, backgroundMusicTracks.Length);
        musicSrc.clip = backgroundMusicTracks[randomIndex];
        musicSrc.volume = musicVolume;
        musicSrc.Play();
    }

    public void StopBackgroundMusic()
    {
        if (musicSrc.isPlaying)
        {
            musicSrc.Stop();
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp(volume, 0f, 1f);
        musicSrc.volume = musicVolume;
    }
}
