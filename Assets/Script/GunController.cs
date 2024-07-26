using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;  // Префаб снаряда
    public Transform projectileParent;   // Пустой объект для хранения снарядов
    private Vector3 projectileStartPosition;
    private GameObject currentProjectile;
    private static bool isQuitting = false;

    void Start()
    {
        if (projectilePrefab != null)
        {
            currentProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, projectileParent);
            projectileStartPosition = currentProjectile.transform.position;
        }
    }

    public void RespawnProjectile()
    {
        if (projectilePrefab != null && currentProjectile == null)
        {
            currentProjectile = Instantiate(projectilePrefab, projectileStartPosition, Quaternion.identity, projectileParent);
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
        if (currentProjectile != null)
        {
            Destroy(currentProjectile);
        }
    }

    void Update()
    {
        if (currentProjectile == null && !isQuitting)
        {
            RespawnProjectile();
        }
    }
}
