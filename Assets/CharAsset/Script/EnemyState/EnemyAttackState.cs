using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");
    private const float TransitionDuration = 0.2f;

    public EnemyAttackState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        FacePlayer();
        enemystateMachine.Weapon.SetDamage(enemystateMachine.AttackDamage, enemystateMachine.AttackKnockback);
        enemystateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
    }

    public override void UpdateState(float deltaTime)
    {   
        //jika selesai animasi attack maka kembali ke chase state
        if (GetNormalizedAnim() >= 1)
        {
            enemystateMachine.SwitchState(new EnemyChaseState(enemystateMachine));
        }

        return;
    }

    public override void ExitState()
    {
        
    }
}