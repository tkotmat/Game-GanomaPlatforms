using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown;
    public Slider musicVolumeSlider;  // Slider for background music volume
    public Slider soundVolumeSlider;  // Slider for sound effects volume

    private MusicBackground musicBackground;
    private Sounds[] soundScripts;  // Array to hold references to all Sounds scripts

    private void Start()
    {
        // Load settings first to get the saved values
        LoadSettings();

        difficultyDropdown.onValueChanged.AddListener(delegate { SaveSettings(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { UpdateMusicVolume(); });
        soundVolumeSlider.onValueChanged.AddListener(delegate { UpdateSoundVolume(); });

        musicBackground = FindObjectOfType<MusicBackground>();
        if (musicBackground != null)
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f); // Set saved value
            musicBackground.SetMusicVolume(musicVolumeSlider.value);
        }

        soundScripts = FindObjectsOfType<Sounds>();  // Find all Sounds scripts in the scene
        soundVolumeSlider.value = PlayerPrefs.GetFloat("soundVolume", 1f); // Set saved value
        UpdateSoundVolume();  // Apply the saved sound volume to all sound scripts
    }

    public void Restart()
    {
        Time.timeScale = 1; // ”бедимс€, что перед запуском корутины Time.timeScale установлен в 1
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveSettings()
    {
        int difficulty = difficultyDropdown.value + 1;
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("soundVolume", soundVolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        int savedDifficulty = PlayerPrefs.GetInt("difficulty", 1) - 1;
        difficultyDropdown.value = savedDifficulty;
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
        soundVolumeSlider.value = PlayerPrefs.GetFloat("soundVolume", 1f);
    }

    private void UpdateMusicVolume()
    {
        if (musicBackground != null)
        {
            musicBackground.SetMusicVolume(musicVolumeSlider.value);
            PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
            PlayerPrefs.Save();
        }
    }

    private void UpdateSoundVolume()
    {
        float volume = soundVolumeSlider.value;
        foreach (var sound in soundScripts)
        {
            sound.SetVolume(volume);
        }
        PlayerPrefs.SetFloat("soundVolume", volume);
        PlayerPrefs.Save();
    }
}
