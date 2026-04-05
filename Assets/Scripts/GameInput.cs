using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private InputActions _actions;

    public static GameInput Instance { get; private set; }

    public event EventHandler OnPlayerAttack;

    private void Awake() 
    {
        Instance = this;
        _actions = new InputActions();
        _actions.Enable();
        _actions.Combat.Attack.started += PlayerAttack_started;
    }

    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector() => _actions.Player.Move.ReadValue<Vector2>();
    public Vector3 GetMousePosition() => Mouse.current.position.ReadValue();
}
