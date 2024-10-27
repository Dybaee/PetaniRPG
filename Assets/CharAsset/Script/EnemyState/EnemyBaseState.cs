using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine enemystateMachine;

    public EnemyBaseState(EnemyStateMachine enemystateMachine)
    {
        this.enemystateMachine = enemystateMachine;
    }

    //menentukan player berada di chase state atau tidak
    protected bool IsInChaseRange()
    {
        //kalo player dead attack range disable
        if (enemystateMachine.Player.isDead)
        {
            return false;
        }

        //vector/jarak x,y,z antara player dan enemy
        float playerDistanceSqr = (enemystateMachine.Player.transform.position - enemystateMachine.transform.position).sqrMagnitude;

        //memastikan jarak antara player dan enemy
        return playerDistanceSqr <= enemystateMachine.PlayerDetection * enemystateMachine.PlayerDetection;
    }

    protected void MoveWithoutMotion(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    //buat gerak
    protected void Move(Vector3 motion, float deltaTime)
    {
        enemystateMachine.Controller.Move((motion + enemystateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FacePlayer()
    {
        //Target
        if (enemystateMachine.Player == null)
        {
            return;
        }

        //Posisi target - posisi player
        Vector3 lookPos = enemystateMachine.Player.transform.position - enemystateMachine.transform.position;

        //Agar tidak nengok atas bawah
        lookPos.y = 0f;

        //Convert vector ke quaternion(unity rotation)
        enemystateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    // Normalizing time of all animation from 0 to 1
    protected float GetNormalizedAnim()
    {
        AnimatorStateInfo currentInfo = enemystateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = enemystateMachine.Animator.GetNextAnimatorStateInfo(0);

        if (enemystateMachine.Animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!enemystateMachine.Animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}