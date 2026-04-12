using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerController>().enabled = false;    
    }
}
