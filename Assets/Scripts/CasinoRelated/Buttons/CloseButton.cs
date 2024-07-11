using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject gameUI;
        [SerializeField] private PlayButton playButton;

        public void CloseGame()
        {
            if (playButton.currentlyPlaying)
                return;

            gameUI.SetActive(false);
            Cursor.visible = false;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

