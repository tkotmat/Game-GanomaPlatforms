using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manuals : MonoBehaviour
{
    public GameObject panel; // ������, ������� ����� ����������
    private const string PanelShownKey = "PanelShownGlobal";

    void Start()
    {
        // ���������, ���� �� ������ ��� ��������
        if (PlayerPrefs.GetInt(PanelShownKey, 0) == 0)
        {
            // ���������� ������
            panel.SetActive(true);

            // ��������� ���������, ��� ������ ���� ��������
            PlayerPrefs.SetInt(PanelShownKey, 1);
            PlayerPrefs.Save();
        }
        else
        {
            // �������� ������, ���� ��� ��� ���� ��������
            panel.SetActive(false);
        }
    }
}
