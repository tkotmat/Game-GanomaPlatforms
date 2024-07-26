using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    [Range(0f, 1f)] public float soundVolume = 1f;  // Volume for sound effects

    private AudioSource audioSrc => GetComponent<AudioSource>();

    private void Start()
    {
        // Load saved sound volume
        soundVolume = PlayerPrefs.GetFloat("soundVolume", soundVolume);
        audioSrc.volume = soundVolume;
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f, float p2 = 1.2f)
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(clip, volume * soundVolume);  // Apply sound volume
    }

    public void SetVolume(float volume)
    {
        soundVolume = Mathf.Clamp(volume, 0f, 1f);
        audioSrc.volume = soundVolume;
    }
}
