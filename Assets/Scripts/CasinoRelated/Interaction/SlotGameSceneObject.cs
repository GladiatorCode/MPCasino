using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotGameSceneObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SlotsUIManager.Instance.TurnUIOn();

        Cursor.visible = true;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
    }
}

