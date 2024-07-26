using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PauseMenu : Sounds
{
    public bool pauseGame;
    public GameObject pauseGameMenu;
    public GameObject panel; // Reference to the UI panel

    void Update()
    {
        // Check if the panel is not active
        if (!panel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
        PlaySound(sounds[0]);
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
        PlaySound(sounds[0], p1: 2f, p2: 1f);
    }

    public void LostMenu()
    {
        PlaySound(sounds[0], p1: 2f, p2: 1f);
        Time.timeScale = 1f;
        StartCoroutine(LoadMenuAfterDelay(0.1f));
    }

    private IEnumerator LoadMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0); // Replace 0 with the index of your menu scene
    }
}
