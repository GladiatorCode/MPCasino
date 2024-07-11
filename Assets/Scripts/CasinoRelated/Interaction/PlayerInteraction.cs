using UnityEngine;
using Fusion;

public class PlayerInteraction : NetworkBehaviour
{
    public float interactionRange = 2.0f; 
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main; 
        if (playerCamera == null)
        {
            Debug.LogError("PlayerInteraction: No camera found on player.");
        }
    }

    void Update()
    {
        if (HasInputAuthority == false)
            return;
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
