using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private Animator cameraAnimator;
    
    private InputAction _moveAction;
    private Vector2 _moveInput;
    private Rigidbody _rb;

    private bool _isDead;

    private const float HorizontalLimit = 5.75f;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        if (_moveAction == null) Debug.LogError("Move action not found in Input Actions asset");

        _rb = GetComponent<Rigidbody>();
        if (_rb == null) Debug.LogError("Rigidbody component missing on Player");

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

        _rb.linearVelocity = new Vector3(
            _moveInput.x * moveSpeed,
            _rb.linearVelocity.y,
            moveSpeed
        );

        // Clamp horizontal position within track bounds
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -HorizontalLimit, HorizontalLimit);
        transform.position = pos;
    }

    private void Die()
    {
        _isDead = true;
        _rb.linearVelocity = Vector3.zero;
        dummyAnimator.SetTrigger("HitObstacle");
        cameraAnimator.SetTrigger("HitObstacle");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= Die;
    }
}