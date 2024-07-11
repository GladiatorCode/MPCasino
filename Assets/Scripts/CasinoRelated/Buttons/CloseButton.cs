using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CloseButton : MonoBehaviour
    {
        public void CloseGame()
        {
            Cursor.visible = false;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

