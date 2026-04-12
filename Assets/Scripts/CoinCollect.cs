using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;
    [SerializeField] private int score = 1;

    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        GameManager.Instance.AddScore(score);
        Destroy(gameObject);
    }
}