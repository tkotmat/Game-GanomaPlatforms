using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionOfThePortalThroughTime : MonoBehaviour
{
    // Время в секундах, через которое объект будет уничтожен
    public float timeToDestroy = 5f;

    void Start()
    {
        // Уничтожение объекта через timeToDestroy секунд
        Destroy(gameObject, timeToDestroy);
    }
}
