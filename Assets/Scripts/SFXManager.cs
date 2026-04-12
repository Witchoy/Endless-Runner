using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource obstacleHitSound;
    [SerializeField] private AudioSource coinPickupSound;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        GameManager.Instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        obstacleHitSound.Play();
    }

    private void OnScoreChanged(int score)
    {
        coinPickupSound.Play();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= OnScoreChanged;
        GameManager.Instance.OnPlayerDeath -= OnPlayerDeath;
    }
}