using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDestroySolo : MonoBehaviour
{
    // Тег, который должен быть у игрока
    public string playerTag = "Player";
    // Ссылка на GameOverCanvas
    public GameObject gameOverCanvas;
    // Время задержки перед показом canvas (в секундах)
    public float delayBeforeShowingCanvas = 0.5f;
    // Ссылка на компонент Sounds
    public Sounds soundManager;
    // Задержка перед уничтожением игрока
    public float delayBeforeDestroyingPlayer = 0.1f;

    // Метод, вызываемый при столкновении коллайдеров
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка, что коллайдер столкнулся с объектом с нужным тегом
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Воспроизведение звука при столкновении
            soundManager.PlaySound(soundManager.sounds[0]);
            // Запуск уничтожения игрока с задержкой
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
        gameOverCanvas.SetActive(true); // Показать UI
    }
}
