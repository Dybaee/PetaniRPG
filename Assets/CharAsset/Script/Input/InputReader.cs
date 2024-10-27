using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerControls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public event Action TargetingEvent;
    public event Action CancelingEvent;
    //public event Action AttackingEvent;

    // UNTUK HOLD DOWN ATTACK
    public bool IsAttacking { get; private set; }
    public bool IsBlocking { get; private set; }

    private PlayerControls controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnTargeting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TargetingEvent?.Invoke();
        }
        return;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) { }

    public void OnCanceling(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CancelingEvent?.Invoke();
        }
        return;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // UNTUK HOLD DOWN ATTACK
        if (context.performed)
        {
            IsAttacking = true;
        }

        if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void ConsumeIsAttacking()
    {
        IsAttacking = false;
    }

    public void OnBlocking(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsBlocking = true;
        }

        if (context.canceled)
        {
            IsBlocking = false;
        }
    }
}
