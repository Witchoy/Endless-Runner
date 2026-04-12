using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private readonly float _rightLimit = 5.75f;
    private InputAction _moveAction;
    private Vector2 _moveInput;

    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        if (_moveAction == null) Debug.LogError("Error occured while initializing move action");

        _playerRigidbody = GetComponent<Rigidbody>();
        if (_playerRigidbody == null) Debug.LogError("Error occurred while initializing rigidbody");
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _playerRigidbody.linearVelocity = new Vector3(
            _moveInput.x * moveSpeed,
            _playerRigidbody.linearVelocity.y,
            moveSpeed
        );

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -_rightLimit, _rightLimit);
        transform.position = pos;
    }

    public void Die()
    {
        Debug.Log("I am dead");
    }
}