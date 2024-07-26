using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    private const string SceneKey = "SavedScene";

    public void SaveGame()
    {
        // ��������� ������� �����
        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(SceneKey, currentSceneName);
        PlayerPrefs.Save();
        Debug.Log("Game Saved: " + currentSceneName);
    }

    public void LoadGame()
    {
        // ��������� ���������� �����
        if (PlayerPrefs.HasKey(SceneKey))
        {
            string savedSceneName = PlayerPrefs.GetString(SceneKey);
            SceneManager.LoadScene(savedSceneName);
            Debug.Log("Game Loaded: " + savedSceneName);
        }
        else
        {
            Debug.Log("No saved game found.");
        }
    }

    public void ResetGame()
    {
        // ������� ���������� ������
        if (PlayerPrefs.HasKey(SceneKey))
        {
            PlayerPrefs.DeleteKey(SceneKey);
            PlayerPrefs.Save();
            Debug.Log("Game reset: saved data deleted.");
        }
        else
        {
            Debug.Log("No saved data to reset.");
        }
    }
}
