using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpactState : EnemyBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("GetHit");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;

    private float duration = 1f;
    public EnemyImpactState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        enemystateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);

        duration -= deltaTime;
        if (duration <= 0f)
        {
            enemystateMachine.SwitchState(new EnemyIdleState(enemystateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}