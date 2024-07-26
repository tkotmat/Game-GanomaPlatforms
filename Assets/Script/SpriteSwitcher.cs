using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public Button button; // Кнопка интерфейса, к которой прикреплен скрипт
    public GameObject newPrefab; // Новый префаб, который заменит текущий спрайт
    public GameObject target; // Объект, на котором нужно заменить спрайт
    public Vector3 newPrefabPosition; // Новое положение для префаба
    private bool canBePressed = true; // Флаг для проверки возможности нажатия

    void Start()
    {
        // Подписываем метод ChangeSprite на событие нажатия кнопки
        if (button != null)
        {
            button.onClick.AddListener(ChangeSprite);
        }
    }

    void Update()
    {
        // Проверяем нажатие клавиши F, если кнопка видима
        if (canBePressed && button.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.F))
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        if (canBePressed && target != null && newPrefab != null)
        {
            // Удаляем текущий спрайт
            Destroy(target);

            // Создаем новый объект из префаба
            GameObject newObject = Instantiate(newPrefab, newPrefabPosition, target.transform.rotation);

            // Назначаем новому объекту родительскую трансформацию целевого объекта
            newObject.transform.SetParent(target.transform.parent);

            // Назначаем новому объекту имя целевого объекта
            newObject.name = target.name;

            // Переназначаем целевой объект на новый объект
            target = newObject;

            // Отключаем возможность повторного нажатия
            canBePressed = false;

            // Отключаем кнопку
            button.interactable = false;
        }
    }
}
