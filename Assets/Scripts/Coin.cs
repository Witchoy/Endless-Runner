using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;
    
    [SerializeField] private int score = 1;
    [SerializeField] private float rotationSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        GameManager.Instance.AddScore(score);
        Destroy(gameObject);
    }
}
