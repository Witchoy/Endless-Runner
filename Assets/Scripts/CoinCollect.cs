using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        MasterInfo.coinCount += 1;
        Destroy(gameObject);
    }
}
