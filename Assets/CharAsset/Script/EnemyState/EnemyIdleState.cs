using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;
    public EnemyIdleState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        enemystateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        if (IsInChaseRange())
        {
            //Transition to Chase State
            enemystateMachine.SwitchState(new EnemyChaseState(enemystateMachine));

            return;
        }
        enemystateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void ExitState()
    {
        
    }
}