using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private float currentAngle = 0f;
    public float rotationSpeed = 2f; // �������� �������� ������
    private float originalRotationSpeed; // �������� �������� ��������
    public bool isRotating = false; // ����, �����������, ����������� �� ��������

    public RotationManager rotationManager; // ������ �� ������ RotationManager

    public float CurrentAngle
    {
        get { return currentAngle; }
    }

    private KeyCode lastKeyPressed; // ���� ��� ������������ ��������� ������� ������
    private int leftArrowPressCount = 0; // ������� ������� LeftArrow
    private int rightArrowPressCount = 0; // ������� ������� RightArrow

    void Start()
    {
        originalRotationSpeed = rotationSpeed; // ��������� �������� �������� ��������
    }

    void Update()
    {
        if (!isRotating && rotationManager.remainingRotations > 0) // ��������, ����������� �� �������� � ���� �� ���������� ��������
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (lastKeyPressed != KeyCode.RightArrow || rightArrowPressCount < 2) // ��������, ���� �� ���������� ������� ������ �� RightArrow ��� ���������� ������� ������ 2
                {
                    StartCoroutine(RotateMap(90f, originalRotationSpeed));
                    lastKeyPressed = KeyCode.RightArrow; // ��������� ��������� ������� ������
                    rightArrowPressCount++;
                    leftArrowPressCount = 0; // ����� �������� ������� ��� LeftArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (lastKeyPressed != KeyCode.LeftArrow || leftArrowPressCount < 2) // ��������, ���� �� ���������� ������� ������ �� LeftArrow ��� ���������� ������� ������ 2
                {
                    StartCoroutine(RotateMap(-90f, originalRotationSpeed));
                    lastKeyPressed = KeyCode.LeftArrow; // ��������� ��������� ������� ������
                    leftArrowPressCount++;
                    rightArrowPressCount = 0; // ����� �������� ������� ��� RightArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (lastKeyPressed != KeyCode.UpArrow) // ��������, ���� �� ���������� ������� ������ �� UpArrow
                {
                    StartCoroutine(RotateMap(180f, originalRotationSpeed / 2)); // ��������� �������� ��������
                    lastKeyPressed = KeyCode.UpArrow; // ��������� ��������� ������� ������
                    leftArrowPressCount = 0; // ����� �������� ������� ��� LeftArrow
                    rightArrowPressCount = 0; // ����� �������� ������� ��� RightArrow
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (lastKeyPressed != KeyCode.DownArrow) // ��������, ���� �� ���������� ������� ������ �� DownArrow
                {
                    StartCoroutine(RotateMap(-180f, originalRotationSpeed / 2)); // ��������� �������� ��������
                    lastKeyPressed = KeyCode.DownArrow; // ��������� ��������� ������� ������
                    leftArrowPressCount = 0; // ����� �������� ������� ��� LeftArrow
                    rightArrowPressCount = 0; // ����� �������� ������� ��� RightArrow
                }
            }
        }
    }

    IEnumerator RotateMap(float angleChange, float speed)
    {
        isRotating = true; // ������������� ���� � true ����� ������� ��������
        float targetAngle = currentAngle + angleChange;
        float startAngle = currentAngle;
        float elapsed = 0f;

        while (elapsed < 1f / speed)
        {
            elapsed += Time.deltaTime * speed;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsed);
            virtualCamera.m_Lens.Dutch = currentAngle;
            yield return null;
        }

        currentAngle = targetAngle;

        // ��������, ��� ���� �� ��������� 360 ��������
        if (currentAngle >= 360f || currentAngle <= -360f)
        {
            currentAngle = 0f;
        }

        virtualCamera.m_Lens.Dutch = currentAngle;
        isRotating = false; // ���������� ���� ����� ���������� ��������

        rotationManager.UseRotation(); // ��������� ���������� ���������� ���������
    }
}
