using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        Animate();
        AdjustPlayerFacingDirection();
    }

    private void Animate() => _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning);
    private void AdjustPlayerFacingDirection() => _spriteRenderer.flipX = GameInput.Instance.GetMousePosition().x < Player.Instance.ScreenPosition.x;
}
