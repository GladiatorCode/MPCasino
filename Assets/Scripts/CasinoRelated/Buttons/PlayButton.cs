using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Texture[] textures;
    public RawImage rawImage;
    private int currentTextureIndex = 0;

    public bool currentlyPlaying = false;
    public SlotsGameManager gameManager;

    public void OnButtonClick()
    {
        if (currentlyPlaying) return;

        //Spin reels
        gameManager.OnSpinButtonClicked();

        Debug.Log("Spining the reels");
        StartCoroutine(CycleTextures());
    }

    IEnumerator CycleTextures()
    {
        currentlyPlaying = true;
        // Loop through the textures with a delay
        for (int i = 0; i < textures.Length; i++)
        {
            currentTextureIndex = (currentTextureIndex + 1) % textures.Length;
            rawImage.texture = textures[currentTextureIndex];
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(2f);
        currentlyPlaying = false;
    }
}

