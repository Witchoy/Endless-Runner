using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    // Events
    public event Action<int> OnScoreChanged;
    public event Action OnPlayerDeath;

    private int _score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score);
    }

    public void GameOver()
    {
        OnPlayerDeath?.Invoke();
    }
}