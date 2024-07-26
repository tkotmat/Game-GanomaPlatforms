using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5f; // �������� �������� � �������� � �������
    private float currentRotation = 0f; // ������� ���� ��������

    void Start()
    {
        // ������ �������� ��� ����������� ��������
        StartCoroutine(Rotate());
    }

    System.Collections.IEnumerator Rotate()
    {
        while (true)
        {
            // ��������� � �������� ���� �������� �������� ��������, ���������� �� ����� ����� �������
            currentRotation += rotationSpeed * Time.deltaTime;

            // ���� ������� ���� �������� ������ ��� �������� 360 ��������, ���������� ���
            if (currentRotation >= 360f)
            {
                currentRotation = 0f;
            }

            // ��������� �������� � �������
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            // ���� �� ���������� �����
            yield return null;
        }
    }
}
