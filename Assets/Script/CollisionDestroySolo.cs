using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDestroySolo : MonoBehaviour
{
    // ���, ������� ������ ���� � ������
    public string playerTag = "Player";
    // ������ �� GameOverCanvas
    public GameObject gameOverCanvas;
    // ����� �������� ����� ������� canvas (� ��������)
    public float delayBeforeShowingCanvas = 0.5f;
    // ������ �� ��������� Sounds
    public Sounds soundManager;
    // �������� ����� ������������ ������
    public float delayBeforeDestroyingPlayer = 0.1f;

    // �����, ���������� ��� ������������ �����������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������, ��� ��������� ���������� � �������� � ������ �����
        if (collision.gameObject.CompareTag(playerTag))
        {
            // ��������������� ����� ��� ������������
            soundManager.PlaySound(soundManager.sounds[0]);
            // ������ ����������� ������ � ���������
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
        gameOverCanvas.SetActive(true); // �������� UI
    }
}
