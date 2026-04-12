using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Info
    private int _score;
    
    // Singleton stuff
    public static GameManager Instance { get; private set; }

    // Events
    public event Action<int> OnScoreChanged;
    public event Action OnPlayerDeath;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public void AddScore(int score)
    {
        _score += score;
        OnScoreChanged?.Invoke(_score);
    }

    public void GameOver()
    {
        
        OnPlayerDeath?.Invoke();
    }
}