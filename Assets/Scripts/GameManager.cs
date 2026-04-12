using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton stuff

    // Game Info
    private int _score;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Events
    public event Action<int> OnScoreChanged;

    public void AddScore(int score)
    {
        _score += score;
        OnScoreChanged?.Invoke(_score);
    }
}