using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDisabler : MonoBehaviour
{
    public GameObject spriteObject; // ���������� ���� ������ �� �������� � ����������
    public float delay = 5f; // ����� �������� ����� ������������� �������

    private void Start()
    {
        // ������ ������ ������� ��� ������� �����
        if (spriteObject != null)
        {
            spriteObject.SetActive(true);
        }

        // ��������� ��������, ����� ��������� 5 ������ ����� ����������� �������
        StartCoroutine(DisableSpriteAfterDelay());
    }

    private IEnumerator DisableSpriteAfterDelay()
    {
        // ��� ��������� ���������� ������
        yield return new WaitForSeconds(delay);

        // ��������� ������ �� ��������
        if (spriteObject != null)
        {
            spriteObject.SetActive(false);
        }
    }
}
