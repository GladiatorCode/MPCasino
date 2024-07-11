using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public string GameScene;

    public void PlayButton()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            
            return;
        }
        // Save the name using PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);

        // Load the next scene
        SceneManager.LoadScene(GameScene);
    }

}

