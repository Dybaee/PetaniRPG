using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeathHash = Animator.StringToHash("Death");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        //anim or ragdoll
        stateMachine.Animator.CrossFadeInFixedTime(DeathHash, CrossFadeDuration);
        stateMachine.Health.UIHealthZero();

        stateMachine.AttackDamageScriptL.gameObject.SetActive(false);
        stateMachine.AttackDamageScriptR?.gameObject.SetActive(false);
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState(float deltaTime)
    {
        
    }
}
