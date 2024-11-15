using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;

    private Vector3 currentPoint;
    
    public EnemyPatrolState(EnemyStateMachine enemystateMachine) : base(enemystateMachine)
    {
    }

    public override void EnterState()
    {
        enemystateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);

        currentPoint = enemystateMachine.centerPoint.GetRandomWaypoint(enemystateMachine.centerPoint.gameObject.transform.position);
    }

    public override void UpdateState(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            if(enemystateMachine.Agent.remainingDistance <= enemystateMachine.Agent.stoppingDistance)
            {
                enemystateMachine.SwitchState(new EnemyPatrolState(enemystateMachine));
            }
        }
        else
        {
            //Transition to Chase State
            enemystateMachine.SwitchState(new EnemyChaseState(enemystateMachine));
            return;
        }    

        PatrollingMove(deltaTime);
        FacePoint();

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

    private void PatrollingMove(float deltaTime)
    {
        if(enemystateMachine.Agent.isOnNavMesh) 
        {
            //enemy bergerak ke player
            enemystateMachine.Agent.destination = currentPoint;

            //kecepatan enemy bergerak ke player
            Move(enemystateMachine.Agent.desiredVelocity.normalized * enemystateMachine.MovementSpeed, deltaTime);
        }

        enemystateMachine.Agent.velocity = enemystateMachine.Controller.velocity;
    }

    private void FacePoint()
    {
        //Posisi target - posisi player
        Vector3 lookPos = currentPoint - enemystateMachine.transform.position;

        //Agar tidak nengok atas bawah
        lookPos.y = 0f;

        //Convert vector ke quaternion(unity rotation)
        enemystateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
