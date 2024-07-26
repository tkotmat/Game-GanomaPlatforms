using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
    public string bonusName;
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (bonusName)
            {
                case "coin":
                    coinManager.AddCoin();
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
