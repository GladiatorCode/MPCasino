using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsGameManager : MonoBehaviour
{
    public Reel[] reels;
    private List<Winnings> winningsList;

    void Start()
    {
        InitializeWinnings();
    }

    public void OnSpinButtonClicked()
    {
        foreach (Reel reel in reels)
        {
            reel.SpinReel();
        }

        StartCoroutine(CheckResults());
    }

    private IEnumerator CheckResults()
    {
        // Wait until all reels have stopped spinning
        yield return new WaitForSeconds(2.0f); // Adjust the delay to match the reel spin duration

        // Collect results from each reel
        string[] finalSymbols = new string[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {
            finalSymbols[i] = reels[i].GetFinalSymbol();
        }

        // Check the result against the winnings
        int payout = GetPayout(finalSymbols);

        // Display result
        if (payout > 0)
        {
            Debug.Log("You win! Payout: " + payout);
        }
        else
        {
            Debug.Log("You lose!");
        }
    }

    private void InitializeWinnings()
    {
        winningsList = new List<Winnings>
    {
        new Winnings(new string[] { "7", "7", "7" }, 1000),
        new Winnings(new string[] { "cherry", "cherry", "cherry" }, 500),
        new Winnings(new string[] { "bell", "bell", "bell" }, 200),
        new Winnings(new string[] { "triplebar", "triplebar", "triplebar" }, 100),
        new Winnings(new string[] { "7", "7", "cherry" }, 50),
        new Winnings(new string[] { "7", "7", "bell" }, 20),
        new Winnings(new string[] { "7", "7", "triplebar" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "bell" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "bell", "bell", "triplebar" }, 5),
        new Winnings(new string[] { "7", "cherry", "bell" }, 3),
        new Winnings(new string[] { "7", "cherry", "triplebar" }, 2),
        new Winnings(new string[] { "7", "bell", "triplebar" }, 2),
        new Winnings(new string[] { "cherry", "bell", "bell" }, 2),
        new Winnings(new string[] { "cherry", "bell", "triplebar" }, 1),
        new Winnings(new string[] { "cherry", "triplebar", "triplebar" }, 1),
        new Winnings(new string[] { "bell", "bell", "bell" }, 3),
        new Winnings(new string[] { "bell", "triplebar", "triplebar" }, 3),
        new Winnings(new string[] { "bell", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "7", "7", "7" }, 1000),
        new Winnings(new string[] { "cherry", "cherry", "cherry" }, 500),
        new Winnings(new string[] { "bell", "bell", "bell" }, 200),
        new Winnings(new string[] { "triplebar", "triplebar", "triplebar" }, 100),
        new Winnings(new string[] { "7", "7", "cherry" }, 50),
        new Winnings(new string[] { "7", "7", "bell" }, 20),
        new Winnings(new string[] { "7", "7", "triplebar" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "bell" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "bell", "bell", "triplebar" }, 5),
        new Winnings(new string[] { "7", "cherry", "bell" }, 3),
        new Winnings(new string[] { "7", "cherry", "triplebar" }, 2),
        new Winnings(new string[] { "7", "bell", "triplebar" }, 2),
        new Winnings(new string[] { "cherry", "bell", "bell" }, 2),
        new Winnings(new string[] { "cherry", "bell", "triplebar" }, 1),
        new Winnings(new string[] { "cherry", "triplebar", "triplebar" }, 1),
        new Winnings(new string[] { "bell", "bell", "bell" }, 3),
        new Winnings(new string[] { "bell", "triplebar", "triplebar" }, 3),
        new Winnings(new string[] { "bell", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "cherry", "cherry", "7" }, 5),
        new Winnings(new string[] { "bell", "7", "bell" }, 5),
        new Winnings(new string[] { "bell", "7", "cherry" }, 5),
        new Winnings(new string[] { "cherry", "7", "triplebar" }, 5),
        new Winnings(new string[] { "cherry", "7", "7" }, 5),
        new Winnings(new string[] { "bell", "bell", "7" }, 5),
        new Winnings(new string[] { "bell", "bell", "cherry" }, 5),
        new Winnings(new string[] { "7", "bell", "7" }, 5),
        new Winnings(new string[] { "7", "cherry", "7" }, 5),
        new Winnings(new string[] { "7", "7", "bell" }, 5),
        new Winnings(new string[] { "7", "7", "cherry" }, 5),
        new Winnings(new string[] { "7", "cherry", "bell" }, 5),
        new Winnings(new string[] { "7", "cherry", "7" }, 5),
        new Winnings(new string[] { "7", "bell", "bell" }, 5),
        new Winnings(new string[] { "7", "bell", "cherry" }, 5),
        new Winnings(new string[] { "7", "triplebar", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "7" }, 5),
        new Winnings(new string[] { "triplebar", "7", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "7", "7" }, 5),
        new Winnings(new string[] { "triplebar", "7", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "7", "triplebar" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "cherry" }, 5),
        new Winnings(new string[] { "7", "7", "7" }, 1000),
        new Winnings(new string[] { "cherry", "cherry", "cherry" }, 500),
        new Winnings(new string[] { "bell", "bell", "bell" }, 200),
        new Winnings(new string[] { "triplebar", "triplebar", "triplebar" }, 100),
        new Winnings(new string[] { "7", "7", "cherry" }, 50),
        new Winnings(new string[] { "7", "7", "bell" }, 20),
        new Winnings(new string[] { "7", "7", "triplebar" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "bell" }, 10),
        new Winnings(new string[] { "cherry", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "bell", "bell", "triplebar" }, 5),
        new Winnings(new string[] { "7", "cherry", "bell" }, 3),
        new Winnings(new string[] { "7", "cherry", "triplebar" }, 2),
        new Winnings(new string[] { "7", "bell", "triplebar" }, 2),
        new Winnings(new string[] { "cherry", "bell", "bell" }, 2),
        new Winnings(new string[] { "cherry", "bell", "triplebar" }, 1),
        new Winnings(new string[] { "cherry", "triplebar", "triplebar" }, 1),
        new Winnings(new string[] { "bell", "bell", "bell" }, 3),
        new Winnings(new string[] { "bell", "triplebar", "triplebar" }, 3),
        new Winnings(new string[] { "bell", "cherry", "triplebar" }, 5),
        new Winnings(new string[] { "cherry", "cherry", "7" }, 5),
        new Winnings(new string[] { "bell", "7", "bell" }, 5),
        new Winnings(new string[] { "bell", "7", "cherry" }, 5),
        new Winnings(new string[] { "cherry", "7", "triplebar" }, 5),
        new Winnings(new string[] { "cherry", "7", "7" }, 5),
        new Winnings(new string[] { "bell", "bell", "7" }, 5),
        new Winnings(new string[] { "bell", "bell", "cherry" }, 5),
        new Winnings(new string[] { "7", "bell", "7" }, 5),
        new Winnings(new string[] { "7", "cherry", "7" }, 5),
        new Winnings(new string[] { "7", "7", "bell" }, 5),
        new Winnings(new string[] { "7", "7", "cherry" }, 5),
        new Winnings(new string[] { "7", "cherry", "bell" }, 5),
        new Winnings(new string[] { "7", "cherry", "7" }, 5),
        new Winnings(new string[] { "7", "bell", "bell" }, 5),
        new Winnings(new string[] { "7", "bell", "cherry" }, 5),
        new Winnings(new string[] { "7", "triplebar", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "7" }, 5),
        new Winnings(new string[] { "triplebar", "7", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "7", "7" }, 5),
        new Winnings(new string[] { "triplebar", "7", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "7", "triplebar" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "cherry", "cherry" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "bell" }, 5),
        new Winnings(new string[] { "triplebar", "bell", "cherry" }, 5),
    };
    }

    private int GetPayout(string[] finalSymbols)
    {
        foreach (Winnings winning in winningsList)
        {
            if (IsMatchingCombination(winning.combination, finalSymbols))
            {
                return winning.payout;
            }
        }

        return 0;
    }

    private bool IsMatchingCombination(string[] combination, string[] symbols)
    {
        if (combination.Length != symbols.Length)
        {
            return false;
        }

        for (int i = 0; i < combination.Length; i++)
        {
            if (combination[i] != symbols[i])
            {
                return false;
            }
        }

        return true;
    }


public class Winnings
{
    public string[] combination;
    public int payout;

    public Winnings(string[] combination, int payout)
    {
        this.combination = combination;
        this.payout = payout;
    }
}
}

