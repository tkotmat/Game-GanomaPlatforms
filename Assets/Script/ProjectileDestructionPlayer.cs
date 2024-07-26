using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestructionPlayer : MonoBehaviour
{
    // ���, ������� ������ ���� � ������
    public string playerTag = "Player";
    // ��� ��� GameOverCanvas
    public string gameOverCanvasTag = "GameOverCanvas";
    // ����� �������� ����� ������� canvas (� ��������)
    public float delayBeforeShowingCanvas = 0.5f;
    // ������ �� GameOverCanvas
    private GameObject gameOverCanvas;

    // �������� ����� ������������ ������
    public float delayBeforeDestroyingPlayer = 0.1f;
    // ������ �� ��������� Sounds
    public Sounds soundManager;

    private void Start()
    {
        // ����� GameOverCanvas �� ����, ������� ���������� �������
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(gameOverCanvasTag))
            {
                gameOverCanvas = obj;
                break;
            }
        }

        // ����� ������ ������ ���� GameOverCanvas �� ��� ������
        if (gameOverCanvas == null)
        {
            Debug.LogError("GameOverCanvas � ��������� ����� �� ������!");
        }
    }

    // �����, ���������� ��� ������������ �����������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������, ��� ��������� ���������� � �������� � ������ �����
        if (collision.gameObject.CompareTag(playerTag))
        {
            // ��������������� �����
            if (soundManager != null)
            {
                soundManager.PlaySound(soundManager.sounds[0]);
            }
            // ������ ����������� ������� ������ � ���������
            StartCoroutine(DestroyPlayerAfterDelay(collision.gameObject));
        }
    }

    private IEnumerator DestroyPlayerAfterDelay(GameObject player)
    {
        yield return new WaitForSeconds(delayBeforeDestroyingPlayer);
        Destroy(player);
        StartCoroutine(ShowGameOverCanvasAfterDelay());
    }

    private IEnumerator ShowGameOverCanvasAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeShowingCanvas);
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // �������� UI
        }
    }
}
