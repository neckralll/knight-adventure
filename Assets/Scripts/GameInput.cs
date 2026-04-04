using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private InputActions _actions;

    private void Awake() 
    {
        Instance = this;
        _actions = new InputActions();
        _actions.Enable();
    }

    public Vector2 GetMovementVector() => _actions.Player.Move.ReadValue<Vector2>();
}
