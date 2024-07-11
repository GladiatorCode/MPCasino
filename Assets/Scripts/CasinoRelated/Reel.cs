using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reel : MonoBehaviour
{
    public Image[] reelSymbols; // Array of symbols to display on the reel
    public Sprite[] symbols;    // Array of possible symbols
    private bool isSpinning = false;
    private int finalSymbolIndex;
    private string[] symbolNames = { "7", "cherry", "bell", "triplebar" }; // Define symbol names in the order of symbols array

    void Start()
    {
        // Initially display random symbols
        for (int i = 0; i < reelSymbols.Length; i++)
        {
            reelSymbols[i].sprite = symbols[Random.Range(0, symbols.Length)];
        }
    }

    public void SpinReel()
    {
        if (!isSpinning)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        isSpinning = true;
        float duration = 2.0f; // Spin duration
        float elapsed = 0f;

        while (elapsed < duration)
        {
            for (int i = 0; i < reelSymbols.Length; i++)
            {
                reelSymbols[i].sprite = symbols[Random.Range(0, symbols.Length)];
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Stop spinning with a final random symbol
        finalSymbolIndex = Random.Range(0, symbols.Length);
        for (int i = 0; i < reelSymbols.Length; i++)
        {
            reelSymbols[i].sprite = symbols[finalSymbolIndex];
        }

        isSpinning = false;
    }

    public string GetFinalSymbol()
    {
        return symbolNames[finalSymbolIndex];
    }
}
