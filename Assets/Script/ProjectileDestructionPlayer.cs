using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestructionPlayer : MonoBehaviour
{
    // Тег, который должен быть у игрока
    public string playerTag = "Player";
    // Тег для GameOverCanvas
    public string gameOverCanvasTag = "GameOverCanvas";
    // Время задержки перед показом canvas (в секундах)
    public float delayBeforeShowingCanvas = 0.5f;
    // Ссылка на GameOverCanvas
    private GameObject gameOverCanvas;

    // Задержка перед уничтожением игрока
    public float delayBeforeDestroyingPlayer = 0.1f;
    // Ссылка на компонент Sounds
    public Sounds soundManager;

    private void Start()
    {
        // Поиск GameOverCanvas по тегу, включая неактивные объекты
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(gameOverCanvasTag))
            {
                gameOverCanvas = obj;
                break;
            }
        }

        // Вывод ошибки только если GameOverCanvas не был найден
        if (gameOverCanvas == null)
        {
            Debug.LogError("GameOverCanvas с указанным тегом не найден!");
        }
    }

    // Метод, вызываемый при столкновении коллайдеров
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка, что коллайдер столкнулся с объектом с нужным тегом
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Воспроизведение звука
            if (soundManager != null)
            {
                soundManager.PlaySound(soundManager.sounds[0]);
            }
            // Запуск уничтожения объекта игрока с задержкой
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
            gameOverCanvas.SetActive(true); // Показать UI
        }
    }
}
