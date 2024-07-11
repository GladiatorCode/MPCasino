using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Fusion;


    public class PlayerNameDisplay : NetworkBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;
        private Transform cameraTransform;
    
    
        [Networked, OnChangedRender(nameof(OnNameChanged))]
        public string NetworkedName { get; set; }
    
        private void Start()
        {
            if (!playerNameText)
            {
                Debug.LogError("PlayerNameText is not assigned.");
                return;
            }
    
            if (Object.HasInputAuthority)
            {
                // Ensure the name is only visible to other players
                playerNameText.gameObject.SetActive(false);
    
                ChangeNameRPC(PlayerPrefs.GetString("PlayerName", "Unknown"));
    
            }
            else
            {
                cameraTransform = Camera.main.transform;
                OnNameChanged();
            }
        }

        private void Update()
        {
            // Ensure playerNameText always faces the camera
            if (cameraTransform != null)
            {
                playerNameText.transform.LookAt(playerNameText.transform.position + cameraTransform.rotation * Vector3.forward,
                    cameraTransform.rotation * Vector3.up);
            }
        }

        private void OnNameChanged()
        {
            playerNameText.text = NetworkedName.ToString();
        }
    
        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        private void ChangeNameRPC(string newName)
        {
            NetworkedName = newName;
        }

}

