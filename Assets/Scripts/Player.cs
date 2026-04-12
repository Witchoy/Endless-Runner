using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private InputAction _moveAction;
    private Vector2 _moveInput;
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;

    private bool _isDead;
    
    private const float RightLimit = 5.75f;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        if (_moveAction == null) Debug.LogError("Error occured while initializing move action");

        _playerRigidbody = GetComponent<Rigidbody>();
        if (_playerRigidbody == null) Debug.LogError("Error occurred while initializing rigidbody");
        
        _playerAnimator = GetComponentInChildren<Animator>();
        if (_playerAnimator  == null) Debug.LogError("Error occurred while initializing animator");
        
        // Subcribe to playerDeath action
        GameManager.Instance.OnPlayerDeath += Die;
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
        if (_isDead) return;
        _playerRigidbody.linearVelocity = new Vector3(
            _moveInput.x * moveSpeed,
            _playerRigidbody.linearVelocity.y,
            moveSpeed
        );

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -RightLimit, RightLimit);
        transform.position = pos;
    }

    private void Die()
    {
        _isDead = true;
        _playerRigidbody.linearVelocity = Vector3.zero;
        _playerAnimator.SetTrigger("HitObstacle");
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= Die;
    }
}