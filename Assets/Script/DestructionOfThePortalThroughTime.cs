using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionOfThePortalThroughTime : MonoBehaviour
{
    // ����� � ��������, ����� ������� ������ ����� ���������
    public float timeToDestroy = 5f;

    void Start()
    {
        // ����������� ������� ����� timeToDestroy ������
        Destroy(gameObject, timeToDestroy);
    }
}
