using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5f; // Скорость вращения в градусах в секунду
    private float currentRotation = 0f; // Текущий угол вращения

    void Start()
    {
        // Запуск корутины для постоянного вращения
        StartCoroutine(Rotate());
    }

    System.Collections.IEnumerator Rotate()
    {
        while (true)
        {
            // Добавляем к текущему углу вращения скорость вращения, умноженную на время между кадрами
            currentRotation += rotationSpeed * Time.deltaTime;

            // Если текущий угол вращения достиг или превысил 360 градусов, сбрасываем его
            if (currentRotation >= 360f)
            {
                currentRotation = 0f;
            }

            // Применяем вращение к объекту
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            // Ждем до следующего кадра
            yield return null;
        }
    }
}
