using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIButtonOnProximity : MonoBehaviour
{
    public GameObject player; // �����
    public Button uiButton; // ������ UI
    public float proximityDistance = 5.0f; // ��������� ��� ����������� ������

    void Update()
    {
        if (player != null && uiButton != null)
        {
            // ������������ ��������� ����� ������� � ��������
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // ���� ����� ���������� ������, ���������� ������
            if (distance <= proximityDistance)
            {
                uiButton.gameObject.SetActive(true);
            }
            else
            {
                uiButton.gameObject.SetActive(false);
            }
        }
    }
}
