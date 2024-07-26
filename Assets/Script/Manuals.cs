using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manuals : MonoBehaviour
{
    public GameObject panel; // Панель, которую нужно отобразить
    private const string PanelShownKey = "PanelShownGlobal";

    void Start()
    {
        // Проверяем, была ли панель уже показана
        if (PlayerPrefs.GetInt(PanelShownKey, 0) == 0)
        {
            // Отображаем панель
            panel.SetActive(true);

            // Сохраняем состояние, что панель была показана
            PlayerPrefs.SetInt(PanelShownKey, 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Скрываем панель, если она уже была показана
            panel.SetActive(false);
        }
    }
}
