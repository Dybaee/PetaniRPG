using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    private readonly int DeathHash = Animator.StringToHash("Death");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;
    public EnemyDeadState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        enemystateMachine.Weapon.gameObject.SetActive(false);

        //anim or ragdoll
        enemystateMachine.Animator.CrossFadeInFixedTime(DeathHash, CrossFadeDuration);

        enemystateMachine.HealthUI.UIHealthZero();

        //enemystateMachine.quest1.Killed();
        GameObject.Destroy(enemystateMachine.Target);
    }

    public override void UpdateState(float deltaTime)
    {

    }

    public override void ExitState()
    {

    }
}