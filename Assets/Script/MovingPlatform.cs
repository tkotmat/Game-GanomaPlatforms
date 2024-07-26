using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // скорость платформы
    public Vector3[] points; // массив точек, через которые будет двигаться платформа
    private int currentPoint = 0; // текущая точка, к которой движется платформа

    void Update()
    {
        if (points.Length == 0) return;

        // двигаем платформу к текущей точке
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint], speed * Time.deltaTime);

        // если платформа достигла текущей точки, переключаемся на следующую
        if (Vector3.Distance(transform.position, points[currentPoint]) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % points.Length;
        }
    }
}
