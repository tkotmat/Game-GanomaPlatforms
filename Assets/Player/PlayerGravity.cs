using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public RotateCamera rotateCameraScript;
    public float rotationSpeed = 2f; // Скорость поворота
    private Rigidbody2D rb;
    private float currentAngle;
    private Vector2 originalGravity; // Оригинальная гравитация

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAngle = rotateCameraScript.CurrentAngle;
        originalGravity = Physics2D.gravity; // Сохраняем оригинальную гравитацию
    }

    void Update()
    {
        if (currentAngle != rotateCameraScript.CurrentAngle)
        {
            StopAllCoroutines();
            StartCoroutine(AdjustGravityAndRotation(rotateCameraScript.CurrentAngle));
        }

        // Ensure Z position remains at 0
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }

    IEnumerator AdjustGravityAndRotation(float targetAngle)
    {
        float startAngle = currentAngle;
        float elapsed = 0f;
        float duration = 1f / rotationSpeed; // Продолжительность поворота зависит от скорости
        Vector2 startGravity = Physics2D.gravity;
        Vector2 targetGravity = Vector2.zero;

        if (targetAngle == 0f)
        {
            targetGravity = new Vector2(0, -9.81f);
        }
        else if (targetAngle == 90f || targetAngle == -270f)
        {
            targetGravity = new Vector2(9.81f, 0);
        }
        else if (targetAngle == 180f || targetAngle == -180f)
        {
            targetGravity = new Vector2(0, 9.81f);
        }
        else if (targetAngle == 270f || targetAngle == -90f)
        {
            targetGravity = new Vector2(-9.81f, 0);
        }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsed / duration);
            Physics2D.gravity = Vector2.Lerp(startGravity, targetGravity, elapsed / duration);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
            yield return null;
        }

        currentAngle = targetAngle;
        Physics2D.gravity = targetGravity;
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }

    void OnDestroy()
    {
        ResetGravity(); // Сбрасываем гравитацию при уничтожении объекта
    }

    void ResetGravity()
    {
        Physics2D.gravity = originalGravity; // Восстанавливаем оригинальную гравитацию
    }
}
