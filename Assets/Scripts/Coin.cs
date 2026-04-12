using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private float rotationSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}