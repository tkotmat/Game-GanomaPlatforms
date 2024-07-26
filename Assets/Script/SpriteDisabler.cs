using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDisabler : MonoBehaviour
{
    public GameObject spriteObject; // Перетащите сюда объект со спрайтом в инспекторе
    public float delay = 5f; // Время задержки перед исчезновением спрайта

    private void Start()
    {
        // Делаем спрайт видимым при запуске сцены
        if (spriteObject != null)
        {
            spriteObject.SetActive(true);
        }

        // Запускаем корутину, чтобы подождать 5 секунд перед отключением спрайта
        StartCoroutine(DisableSpriteAfterDelay());
    }

    private IEnumerator DisableSpriteAfterDelay()
    {
        // Ждём указанное количество секунд
        yield return new WaitForSeconds(delay);

        // Отключаем объект со спрайтом
        if (spriteObject != null)
        {
            spriteObject.SetActive(false);
        }
    }
}
