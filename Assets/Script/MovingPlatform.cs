using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // �������� ���������
    public Vector3[] points; // ������ �����, ����� ������� ����� ��������� ���������
    private int currentPoint = 0; // ������� �����, � ������� �������� ���������

    void Update()
    {
        if (points.Length == 0) return;

        // ������� ��������� � ������� �����
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint], speed * Time.deltaTime);

        // ���� ��������� �������� ������� �����, ������������� �� ���������
        if (Vector3.Distance(transform.position, points[currentPoint]) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % points.Length;
        }
    }
}
