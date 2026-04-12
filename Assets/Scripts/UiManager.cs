using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = $"Coins: {score}";
    }
}