using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDestroyGroup : MonoBehaviour
{
    public GameObject gameOverCanvas; // Ссылка на GameOverCanvas
    public float delayBeforeShowingCanvas = 0.5f; // Задержка в секундах
    public Sounds soundManager; // Ссылка на компонент Sounds
    public float delayBeforeDestroyingPlayer = 0.1f; // Задержка перед уничтожением игрока

    void Start()
    {
        // Получаем все компоненты Collider2D у всех дочерних объектов
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

        // Добавляем каждому из них скрипт ChildCollisionHandler
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject) // Исключаем сам объект с этим скриптом
            {
                ChildCollisionHandler handler = collider.gameObject.AddComponent<ChildCollisionHandler>();
                handler.Initialize(gameOverCanvas, delayBeforeShowingCanvas, soundManager, delayBeforeDestroyingPlayer); // Передаем ссылки на gameOverCanvas, задержку и soundManager
            }
        }
    }

    // Вложенный класс для обработки столкновений
    public class ChildCollisionHandler : MonoBehaviour
    {
        private GameObject gameOverCanvas;
        private float delay;
        private Sounds soundManager; // Ссылка на компонент Sounds
        private float delayBeforeDestroyingPlayer; // Задержка перед уничтожением игрока

        // Метод инициализации для передачи ссылок на gameOverCanvas, задержки и soundManager
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
                soundManager.PlaySound(soundManager.sounds[0]); // Вызов функции PlaySound
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
            gameOverCanvas.SetActive(true); // Показать UI
        }
    }
}

