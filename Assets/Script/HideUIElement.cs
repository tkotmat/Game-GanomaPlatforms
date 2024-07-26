using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIElement : MonoBehaviour
{
    public GameObject uiElement; // Ссылка на объект интерфейса, который нужно сделать невидимым

    public void HideElement()
    {
        uiElement.SetActive(false); // Делаем объект неактивным, тем самым он становится невидимым
    }
}
