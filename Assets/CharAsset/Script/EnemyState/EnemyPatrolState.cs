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

        currentPoint = enemystateMachine.centerPoint.GetRandomWaypoint(enemystateMachine.centerPoint.gameObject.transform.position, enemystateMachine.centerPoint.radius);
    }

    public override void UpdateState(float deltaTime)
    {
        PatrollingMove(deltaTime);
        FacePoint();

        if (IsInChaseRange())
        {
            //Transition to Chase State
            enemystateMachine.SwitchState(new EnemyChaseState(enemystateMachine));

            return;
        }

        if(enemystateMachine.Agent.remainingDistance <= enemystateMachine.Agent.stoppingDistance)
        {
            enemystateMachine.SwitchState(new EnemyPatrolState(enemystateMachine));
        }

        enemystateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void ExitState()
    {
        
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
