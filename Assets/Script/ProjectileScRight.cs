using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScRight : MonoBehaviour
{
    public float speed = 5f;
    public float targetXPosition = 10f; // изменено на положительное значение для движения вправо
    private Vector3 initialPosition;
    private static bool isQuitting = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // изменено на Vector3.right для движения вправо

        if (transform.position.x >= targetXPosition) // изменено на проверку позиции справа
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            GunController cannon = FindObjectOfType<GunController>();
            if (cannon != null)
            {
                cannon.RespawnProjectile();
            }
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
