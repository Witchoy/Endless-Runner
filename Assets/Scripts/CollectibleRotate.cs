using UnityEngine;

public class CollectibleRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.5f;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}