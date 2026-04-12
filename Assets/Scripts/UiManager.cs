using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject fadeOutImage;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        GameManager.Instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = $"Coins: {score}";
    }

    private void OnPlayerDeath()
    {
        StartCoroutine(ShowGameOverScreen());
    }

    private IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(3f);
        fadeOutImage.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= OnScoreChanged;
        GameManager.Instance.OnPlayerDeath -= OnPlayerDeath;
    }
}