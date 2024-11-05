using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnState : PlayerBaseState
{
    private float timer = 0.5f;
    public PlayerRespawnState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        stateMachine.Health.ResetHealth();
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        timer -= deltaTime;
        if (timer <= 0)
        {
            timer = 0f;
        }

        if(timer == 0f)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
        else{return;}
    }

    public override void ExitState()
    {
        
    }
}
