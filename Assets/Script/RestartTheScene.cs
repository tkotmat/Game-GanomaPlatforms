using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTheScene : Sounds
{
    public int menuSceneIndex = 0; // Установите индекс сцены с меню

    public void Retry()
    {
        PlaySound(sounds[0], p1: 2f, p2: 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        PlaySound(sounds[0], p1: 2f, p2: 1f);
        SceneManager.LoadScene(menuSceneIndex); // Загрузка сцены по индексу
    }
}
