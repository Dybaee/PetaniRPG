using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;
    public EnemyChaseState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        enemystateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            if(enemystateMachine.EnemyStand)
            {
                enemystateMachine.SwitchState(new EnemyIdleState(enemystateMachine));
            }
            else
            {
                enemystateMachine.SwitchState(new EnemyPatrolState(enemystateMachine));
            }
            return;
        }
        else if (IsInAttackRange())
        {
            enemystateMachine.SwitchState(new EnemyAttackState(enemystateMachine));
            return;
        }


        MoveToPlayer(deltaTime);
        FacePlayer();
        enemystateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void ExitState()
    {
        if (enemystateMachine.Agent.isOnNavMesh)
        {
            //mereset path setelah diluar range(tidak mengikuti player)
            enemystateMachine.Agent.ResetPath();

            //reset velocity
            enemystateMachine.Agent.velocity = Vector3.zero;
        }
    }

    private void MoveToPlayer(float deltaTime)
    {
        if (enemystateMachine.Agent.isOnNavMesh)
        {
            //enemy bergerak ke player
            enemystateMachine.Agent.destination = enemystateMachine.Player.transform.position;

            //kecepatan enemy bergerak ke player
            Move(enemystateMachine.Agent.desiredVelocity.normalized * enemystateMachine.MovementSpeed, deltaTime);
        }

        //char controller dan navmesh agent bisa sync(bergerak di kecepatan sama)
        enemystateMachine.Agent.velocity = enemystateMachine.Controller.velocity;
    }

    private bool IsInAttackRange()
    {
        //kalo player dead attack range disable
        if (enemystateMachine.Player.isDead) { return false; }

        float playerDistanceSqr = (enemystateMachine.Player.transform.position - enemystateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= enemystateMachine.AttackRange * enemystateMachine.AttackRange;
    }
}