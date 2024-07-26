using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private float currentAngle = 0f;
    public float rotationSpeed = 2f; // Скорость поворота камеры
    private float originalRotationSpeed; // Исходная скорость вращения
    public bool isRotating = false; // Флаг, указывающий, выполняется ли вращение

    public RotationManager rotationManager; // Ссылка на скрипт RotationManager

    public float CurrentAngle
    {
        get { return currentAngle; }
    }

    private KeyCode lastKeyPressed; // Флаг для отслеживания последней нажатой кнопки
    private int leftArrowPressCount = 0; // Счетчик нажатий LeftArrow
    private int rightArrowPressCount = 0; // Счетчик нажатий RightArrow

    void Start()
    {
        originalRotationSpeed = rotationSpeed; // Сохраняем исходную скорость вращения
    }

    void Update()
    {
        if (!isRotating && rotationManager.remainingRotations > 0) // Проверка, выполняется ли вращение и есть ли оставшиеся повороты
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (lastKeyPressed != KeyCode.RightArrow || rightArrowPressCount < 2) // Проверка, была ли предыдущая нажатая кнопка не RightArrow или количество нажатий меньше 2
                {
                    StartCoroutine(RotateMap(90f, originalRotationSpeed));
                    lastKeyPressed = KeyCode.RightArrow; // Обновляем последнюю нажатую кнопку
                    rightArrowPressCount++;
                    leftArrowPressCount = 0; // Сброс счетчика нажатий для LeftArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (lastKeyPressed != KeyCode.LeftArrow || leftArrowPressCount < 2) // Проверка, была ли предыдущая нажатая кнопка не LeftArrow или количество нажатий меньше 2
                {
                    StartCoroutine(RotateMap(-90f, originalRotationSpeed));
                    lastKeyPressed = KeyCode.LeftArrow; // Обновляем последнюю нажатую кнопку
                    leftArrowPressCount++;
                    rightArrowPressCount = 0; // Сброс счетчика нажатий для RightArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (lastKeyPressed != KeyCode.UpArrow) // Проверка, была ли предыдущая нажатая кнопка не UpArrow
                {
                    StartCoroutine(RotateMap(180f, originalRotationSpeed / 2)); // Уменьшаем скорость вращения
                    lastKeyPressed = KeyCode.UpArrow; // Обновляем последнюю нажатую кнопку
                    leftArrowPressCount = 0; // Сброс счетчика нажатий для LeftArrow
                    rightArrowPressCount = 0; // Сброс счетчика нажатий для RightArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (lastKeyPressed != KeyCode.DownArrow) // Проверка, была ли предыдущая нажатая кнопка не DownArrow
                {
                    StartCoroutine(RotateMap(-180f, originalRotationSpeed / 2)); // Уменьшаем скорость вращения
                    lastKeyPressed = KeyCode.DownArrow; // Обновляем последнюю нажатую кнопку
                    leftArrowPressCount = 0; // Сброс счетчика нажатий для LeftArrow
                    rightArrowPressCount = 0; // Сброс счетчика нажатий для RightArrow
                }
            }
        }
    }

    IEnumerator RotateMap(float angleChange, float speed)
    {
        isRotating = true; // Устанавливаем флаг в true перед началом вращения
        float targetAngle = currentAngle + angleChange;
        float startAngle = currentAngle;
        float elapsed = 0f;

        while (elapsed < 1f / speed)
        {
            elapsed += Time.deltaTime * speed;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsed);
            virtualCamera.m_Lens.Dutch = currentAngle;
            yield return null;
        }

        currentAngle = targetAngle;

        // Убедимся, что угол не превышает 360 градусов
        if (currentAngle >= 360f || currentAngle <= -360f)
        {
            currentAngle = 0f;
        }

        virtualCamera.m_Lens.Dutch = currentAngle;
        isRotating = false; // Сбрасываем флаг после завершения вращения

        rotationManager.UseRotation(); // Уменьшаем количество оставшихся поворотов
    }
}
