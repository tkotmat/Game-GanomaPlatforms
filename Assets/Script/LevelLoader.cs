using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public TextMeshProUGUI staticText; // Ссылка на TextMeshProUGUI для статической надписи
    public TextMeshProUGUI levelText; // Ссылка на TextMeshProUGUI для номера уровня
    public float displayTime = 5f; // Время отображения текста
    public float delayBeforeDisplay = 5f; // Задержка перед началом отображения текста

    private void Start()
    {
        // Скрыть текст в начале
        staticText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);

        StartCoroutine(DisplayLevelText());
    }

    private IEnumerator DisplayLevelText()
    {
        yield return new WaitForSeconds(delayBeforeDisplay); // Подождать заданное время перед отображением текста

        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        staticText.text = "Level:";
        levelText.text = levelIndex.ToString();

        staticText.gameObject.SetActive(true); // Отобразить статический текст
        levelText.gameObject.SetActive(true); // Отобразить текст номера уровня

        yield return new WaitForSeconds(displayTime); // Подождать время отображения текста

        staticText.gameObject.SetActive(false); // Скрыть статический текст
        levelText.gameObject.SetActive(false); // Скрыть текст номера уровня
    }
}
