using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("GetHit");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;

    private float duration = 0.5f;
    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        stateMachine.AttackDamageScriptL.gameObject.SetActive(false);
        stateMachine.AttackDamageScriptR?.gameObject.SetActive(false);
        stateMachine.SFXAudio.PlayOneShot(stateMachine.SoundEffect[1]);
        stateMachine.Health.UIHealthDecreaseUpdate();
        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
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