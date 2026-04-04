using UnityEngine;

public class Player : MonoBehaviour
{
    private const float MIN_MOVE_SPEED = 0.1f;

    private Rigidbody2D _rb;

    [SerializeField] private float moveSpeed;

    public static Player Instance { get; private set; }
    public bool IsRunning { get; private set; }
    public Vector3 ScreenPosition => Camera.main.WorldToScreenPoint(transform.position);

    private void Awake() 
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var input = GameInput.Instance.GetMovementVector();
        var delta = input * (moveSpeed * Time.fixedDeltaTime);

        _rb.MovePosition(_rb.position + delta);
        IsRunning = input.sqrMagnitude > MIN_MOVE_SPEED * MIN_MOVE_SPEED;
    }
}
