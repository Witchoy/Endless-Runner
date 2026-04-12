using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        Destroy(gameObject);
    }
}
