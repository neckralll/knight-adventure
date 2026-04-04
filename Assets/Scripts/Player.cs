using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput() => _rb.MovePosition(_rb.position + GameInput.Instance.GetMovementVector() * (moveSpeed * Time.fixedDeltaTime));
}
