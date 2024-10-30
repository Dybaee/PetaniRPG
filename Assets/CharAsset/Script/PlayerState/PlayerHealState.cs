using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealState : PlayerBaseState
{
    private readonly int HealHash = Animator.StringToHash("Heal");

    private const float CrossFadeDuration = 0.2f;

    private float duration = 1f;
    private int healChancesDecrease = 1;
    public PlayerHealState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        if (stateMachine.Health.currentHealth == 100)
        {
            Debug.Log("Your health is full!");
        }
        else if (stateMachine.Health.HealChances <= 0)
        {
            Debug.Log("You're no longer able to heal!");
        }
        else
        {
            //stateMachine.AudioSource.Play();
            stateMachine.Animator.CrossFadeInFixedTime(HealHash, CrossFadeDuration);           
            stateMachine.Health.HealSystem(stateMachine.HealValue);
            stateMachine.Health.HealChances -= healChancesDecrease;
        }       
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        duration -= deltaTime;
        if (duration <= 0f)
        {
            ReturnToAnyLocomotion();
        }
    }

    public override void ExitState()
    {
        
    }    
}
