using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private InputActions _actions;

    public static GameInput Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
        _actions = new InputActions();
        _actions.Enable();
    }

    public Vector2 GetMovementVector() => _actions.Player.Move.ReadValue<Vector2>();
    public Vector3 GetMousePosition() => Mouse.current.position.ReadValue();
}
