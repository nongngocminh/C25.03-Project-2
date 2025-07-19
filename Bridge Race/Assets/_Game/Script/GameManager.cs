using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerBrickCount = 0;
    [SerializeField] public int botCount;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager found! Destroying this new instance.");
            Destroy(gameObject);
        }
    }

    public void IncreaseBrickCount()
    {
        playerBrickCount++;
    }

    public void DecreaseBrickCount()
    {
        playerBrickCount--;
    }
}
