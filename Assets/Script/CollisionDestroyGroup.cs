using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDestroyGroup : MonoBehaviour
{
    public GameObject gameOverCanvas; // ������ �� GameOverCanvas
    public float delayBeforeShowingCanvas = 0.5f; // �������� � ��������
    public Sounds soundManager; // ������ �� ��������� Sounds
    public float delayBeforeDestroyingPlayer = 0.1f; // �������� ����� ������������ ������

    void Start()
    {
        // �������� ��� ���������� Collider2D � ���� �������� ��������
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

        // ��������� ������� �� ��� ������ ChildCollisionHandler
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject) // ��������� ��� ������ � ���� ��������
            {
                ChildCollisionHandler handler = collider.gameObject.AddComponent<ChildCollisionHandler>();
                handler.Initialize(gameOverCanvas, delayBeforeShowingCanvas, soundManager, delayBeforeDestroyingPlayer); // �������� ������ �� gameOverCanvas, �������� � soundManager
            }
        }
    }

    // ��������� ����� ��� ��������� ������������
    public class ChildCollisionHandler : MonoBehaviour
    {
        private GameObject gameOverCanvas;
        private float delay;
        private Sounds soundManager; // ������ �� ��������� Sounds
        private float delayBeforeDestroyingPlayer; // �������� ����� ������������ ������

        // ����� ������������� ��� �������� ������ �� gameOverCanvas, �������� � soundManager
        public void Initialize(GameObject canvas, float delay, Sounds soundManager, float delayBeforeDestroyingPlayer)
        {
            gameOverCanvas = canvas;
            this.delay = delay;
            this.soundManager = soundManager;
            this.delayBeforeDestroyingPlayer = delayBeforeDestroyingPlayer;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                soundManager.PlaySound(soundManager.sounds[0]); // ����� ������� PlaySound
                StartCoroutine(DestroyPlayerAfterDelay(collision.collider.gameObject));
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
            yield return new WaitForSeconds(delay);
            gameOverCanvas.SetActive(true); // �������� UI
        }
    }
}

