using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public Button button; // ������ ����������, � ������� ���������� ������
    public GameObject newPrefab; // ����� ������, ������� ������� ������� ������
    public GameObject target; // ������, �� ������� ����� �������� ������
    public Vector3 newPrefabPosition; // ����� ��������� ��� �������
    private bool canBePressed = true; // ���� ��� �������� ����������� �������

    void Start()
    {
        // ����������� ����� ChangeSprite �� ������� ������� ������
        if (button != null)
        {
            button.onClick.AddListener(ChangeSprite);
        }
    }

    void Update()
    {
        // ��������� ������� ������� F, ���� ������ ������
        if (canBePressed && button.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.F))
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        if (canBePressed && target != null && newPrefab != null)
        {
            // ������� ������� ������
            Destroy(target);

            // ������� ����� ������ �� �������
            GameObject newObject = Instantiate(newPrefab, newPrefabPosition, target.transform.rotation);

            // ��������� ������ ������� ������������ ������������� �������� �������
            newObject.transform.SetParent(target.transform.parent);

            // ��������� ������ ������� ��� �������� �������
            newObject.name = target.name;

            // ������������� ������� ������ �� ����� ������
            target = newObject;

            // ��������� ����������� ���������� �������
            canBePressed = false;

            // ��������� ������
            button.interactable = false;
        }
    }
}
