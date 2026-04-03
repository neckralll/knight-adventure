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
        var inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            inputVector.y = 1f;

        if (Input.GetKey(KeyCode.A))
            inputVector.x = -1f;

        if (Input.GetKey(KeyCode.S))
            inputVector.y = -1f;

        if (Input.GetKey(KeyCode.D))
            inputVector.x = 1f;

        _rb.MovePosition(_rb.position + inputVector.normalized * (moveSpeed * Time.fixedDeltaTime));
    }
}
