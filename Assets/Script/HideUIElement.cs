using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIElement : MonoBehaviour
{
    public GameObject uiElement; // ������ �� ������ ����������, ������� ����� ������� ���������

    public void HideElement()
    {
        uiElement.SetActive(false); // ������ ������ ����������, ��� ����� �� ���������� ���������
    }
}
