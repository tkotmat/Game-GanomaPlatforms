using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    private int localCoins;
    private int globalCoins;
    public Sounds soundManager;

    private void Start()
    {
        localCoins = 0;
        globalCoins = PlayerPrefs.GetInt("globalCoins", 0);
        UpdateCoinText();
    }

    public void AddCoin()
    {
        soundManager.PlaySound(soundManager.sounds[0]);
        localCoins++;
        UpdateCoinText();
    }

    public void SaveGlobalCoins()
    {
        globalCoins += localCoins;
        PlayerPrefs.SetInt("globalCoins", globalCoins);
        PlayerPrefs.Save();
        localCoins = 0; // —брасываем локальные монеты после сохранени€
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        textCoin.text = (globalCoins + localCoins).ToString();
    }

    public void ResetCoins()
    {
        localCoins = 0;
        globalCoins = 0;
        PlayerPrefs.SetInt("globalCoins", globalCoins);
        PlayerPrefs.Save();
        UpdateCoinText();
    }
}
