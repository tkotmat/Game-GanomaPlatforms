using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotationManager : MonoBehaviour
{
    public RotateCamera rotateCamera; // Ссылка на скрипт RotateCamera
    public TextMeshProUGUI rotationText; // Ссылка на текстовый элемент UI для отображения оставшихся поворотов
    public int remainingRotations = 10; // Публичная переменная для отслеживания оставшихся поворотов
    public GameObject noRotationsUI; // Ссылка на UI-элемент, который будет отображаться при достижении нуля
    public float delayBeforeShowingUI = 2f; // Задержка перед показом UI
    public GameSettings gameSettings; // Ссылка на скрипт GameSettings

    private bool isDelayed = false; // Флаг для отслеживания задержки

    void Start()
    {
        // Получаем сохранённый уровень сложности
        int savedDifficulty = PlayerPrefs.GetInt("difficulty", 1);

        // Делим количество поворотов на сохранённый уровень сложности
        remainingRotations /= savedDifficulty;

        UpdateRotationText(); // Обновляем текст в начале
        noRotationsUI.SetActive(false); // Скрываем UI в начале
    }

    void Update()
    {
        // Проверка, если количество поворотов равно нулю и задержка еще не началась
        if (remainingRotations <= 0 && !isDelayed)
        {
            StartCoroutine(ShowNoRotationsUIWithDelay()); // Запускаем задержку перед показом UI
            isDelayed = true; // Устанавливаем флаг задержки
        }
    }

    // Метод для уменьшения количества оставшихся поворотов и обновления текста
    public void UseRotation()
    {
        if (remainingRotations > 0)
        {
            remainingRotations--;
            UpdateRotationText();
        }
    }

    // Метод для обновления текста UI
    void UpdateRotationText()
    {
        if (rotationText != null)
        {
            rotationText.text = remainingRotations.ToString();
        }
    }

    // Корутина для задержки перед показом UI
    IEnumerator ShowNoRotationsUIWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeShowingUI);

        rotateCamera.enabled = false; // Отключаем возможность поворота в RotateCamera
        noRotationsUI.SetActive(true); // Показываем UI
    }
}
