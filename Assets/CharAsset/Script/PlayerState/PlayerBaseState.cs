using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    protected void MovePlayer(Vector3 motion, float deltaTime) 
    {
        stateMachine.CharController.Move((motion + stateMachine.ForceReceiverScript.Movement) * deltaTime);
    }

    protected void MoveWithoutMotion(float deltaTime)
    {
        MovePlayer(Vector3.zero, deltaTime);
    }

    protected void FaceToTarget()
    {
        if(stateMachine.TargeterScript.CurrentTarget == null) { return; }

        Vector3 lookPos = stateMachine.TargeterScript.CurrentTarget.transform.position - stateMachine.transform.position;
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    protected void ReturnToAnyLocomotion()
    {
        if(stateMachine.TargeterScript.CurrentTarget != null)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
        else
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}