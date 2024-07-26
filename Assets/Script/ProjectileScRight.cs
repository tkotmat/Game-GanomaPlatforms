using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScRight : MonoBehaviour
{
    public float speed = 5f;
    public float targetXPosition = 10f; // �������� �� ������������� �������� ��� �������� ������
    private Vector3 initialPosition;
    private static bool isQuitting = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // �������� �� Vector3.right ��� �������� ������

        if (transform.position.x >= targetXPosition) // �������� �� �������� ������� ������
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
