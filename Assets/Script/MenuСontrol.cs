using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuСontrol : Sounds
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlaySound(sounds[0], p1: 2f, p2: 1f);
    }

    public void ExitGame()
    {
        Debug.Log("игра закрылась");
        Application.Quit();
        PlaySound(sounds[0], p1: 2f, p2: 1f);
    }
}
