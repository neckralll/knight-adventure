using System;
using UnityEngine;

public class SlashVisual : MonoBehaviour
{
    private const string ATTACK_TRIGGER = "Attack";

    [SerializeField] private Sword sword;

    private Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, EventArgs e)
    {
        _animator.SetTrigger(ATTACK_TRIGGER);
    }
}
