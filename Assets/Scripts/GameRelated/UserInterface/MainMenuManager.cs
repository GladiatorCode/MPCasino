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

    // This method will be called when the button is clicked
    public void PlayButton()
    {
        // Get the name from the input field
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            // Do nothing if the name field is empty
            return;
        }
        // Save the name using PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);

        // Load the next scene
        SceneManager.LoadScene(GameScene);
    }

}

