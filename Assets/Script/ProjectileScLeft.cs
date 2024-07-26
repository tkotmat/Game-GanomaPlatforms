using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScLeft : MonoBehaviour
{
    public float speed = 5f;
    public float targetXPosition = -10f;
    private Vector3 initialPosition;
    private static bool isQuitting = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= targetXPosition)
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
