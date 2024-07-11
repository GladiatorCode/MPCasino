using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsUIManager : MonoBehaviour
{
    public GameObject slotsUserInterface;
    private static SlotsUIManager _instance;

    public static SlotsUIManager Instance
    {
        get
        {
           
            if (_instance == null)
            {
                _instance = FindObjectOfType<SlotsUIManager>();

                
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(SlotsUIManager).ToString());
                    _instance = singleton.AddComponent<SlotsUIManager>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return _instance;
        }
    }

    public void TurnUIOn()
    {
        slotsUserInterface.SetActive(true);
    }

    public void TurnUIOff()
    {
        slotsUserInterface.SetActive(false);
    }

}