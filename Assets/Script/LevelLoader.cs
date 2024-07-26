using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public TextMeshProUGUI staticText; // ������ �� TextMeshProUGUI ��� ����������� �������
    public TextMeshProUGUI levelText; // ������ �� TextMeshProUGUI ��� ������ ������
    public float displayTime = 5f; // ����� ����������� ������
    public float delayBeforeDisplay = 5f; // �������� ����� ������� ����������� ������

    private void Start()
    {
        // ������ ����� � ������
        staticText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);

        StartCoroutine(DisplayLevelText());
    }

    private IEnumerator DisplayLevelText()
    {
        yield return new WaitForSeconds(delayBeforeDisplay); // ��������� �������� ����� ����� ������������ ������

        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        staticText.text = "Level:";
        levelText.text = levelIndex.ToString();

        staticText.gameObject.SetActive(true); // ���������� ����������� �����
        levelText.gameObject.SetActive(true); // ���������� ����� ������ ������

        yield return new WaitForSeconds(displayTime); // ��������� ����� ����������� ������

        staticText.gameObject.SetActive(false); // ������ ����������� �����
        levelText.gameObject.SetActive(false); // ������ ����� ������ ������
    }
}
