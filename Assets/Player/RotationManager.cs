using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotationManager : MonoBehaviour
{
    public RotateCamera rotateCamera; // ������ �� ������ RotateCamera
    public TextMeshProUGUI rotationText; // ������ �� ��������� ������� UI ��� ����������� ���������� ���������
    public int remainingRotations = 10; // ��������� ���������� ��� ������������ ���������� ���������
    public GameObject noRotationsUI; // ������ �� UI-�������, ������� ����� ������������ ��� ���������� ����
    public float delayBeforeShowingUI = 2f; // �������� ����� ������� UI
    public GameSettings gameSettings; // ������ �� ������ GameSettings

    private bool isDelayed = false; // ���� ��� ������������ ��������

    void Start()
    {
        // �������� ���������� ������� ���������
        int savedDifficulty = PlayerPrefs.GetInt("difficulty", 1);

        // ����� ���������� ��������� �� ���������� ������� ���������
        remainingRotations /= savedDifficulty;

        UpdateRotationText(); // ��������� ����� � ������
        noRotationsUI.SetActive(false); // �������� UI � ������
    }

    void Update()
    {
        // ��������, ���� ���������� ��������� ����� ���� � �������� ��� �� ��������
        if (remainingRotations <= 0 && !isDelayed)
        {
            StartCoroutine(ShowNoRotationsUIWithDelay()); // ��������� �������� ����� ������� UI
            isDelayed = true; // ������������� ���� ��������
        }
    }

    // ����� ��� ���������� ���������� ���������� ��������� � ���������� ������
    public void UseRotation()
    {
        if (remainingRotations > 0)
        {
            remainingRotations--;
            UpdateRotationText();
        }
    }

    // ����� ��� ���������� ������ UI
    void UpdateRotationText()
    {
        if (rotationText != null)
        {
            rotationText.text = remainingRotations.ToString();
        }
    }

    // �������� ��� �������� ����� ������� UI
    IEnumerator ShowNoRotationsUIWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeShowingUI);

        rotateCamera.enabled = false; // ��������� ����������� �������� � RotateCamera
        noRotationsUI.SetActive(true); // ���������� UI
    }
}
