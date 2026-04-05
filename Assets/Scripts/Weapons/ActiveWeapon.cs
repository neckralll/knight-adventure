using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public static ActiveWeapon Instance { get; private set; }

    [SerializeField] private Sword sword;

    private void Awake() 
    {
        Instance = this;
    }

    private void Update() 
    {
        FollowMousePosition();
    }

    public Sword GetActiveWeapon() => sword;

    private void FollowMousePosition() 
    { 
        if (GameInput.Instance.GetMousePosition().x < Player.Instance.ScreenPosition.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else 
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
