using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIButtonOnProximity : MonoBehaviour
{
    public GameObject player; // Игрок
    public Button uiButton; // Кнопка UI
    public float proximityDistance = 5.0f; // Дистанция для отображения кнопки

    void Update()
    {
        if (player != null && uiButton != null)
        {
            // Рассчитываем дистанцию между игроком и спрайтом
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // Если игрок достаточно близко, показываем кнопку
            if (distance <= proximityDistance)
            {
                uiButton.gameObject.SetActive(true);
            }
            else
            {
                uiButton.gameObject.SetActive(false);
            }
        }
    }
}
