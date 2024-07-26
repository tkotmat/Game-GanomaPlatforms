using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openDoorSprite;
    private Sprite closedDoorSprite;
    private bool isOpen = false;

    private void Start()
    {
        closedDoorSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            GetComponent<SpriteRenderer>().sprite = openDoorSprite;
            isOpen = true;
            GetComponent<Collider2D>().enabled = false; // ќтключить коллайдер, чтобы игрок мог пройти
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            GetComponent<SpriteRenderer>().sprite = closedDoorSprite;
            isOpen = false;
            GetComponent<Collider2D>().enabled = true; // ¬ключить коллайдер, чтобы игрок не мог пройти
        }
    }
}
