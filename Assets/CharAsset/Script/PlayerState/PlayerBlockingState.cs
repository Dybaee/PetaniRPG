using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockingState : PlayerBaseState
{
    private readonly int BlockHash = Animator.StringToHash("Block");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;
    public PlayerBlockingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        stateMachine.Health.SetInvulnerableBlock(true);
        stateMachine.Animator.CrossFadeInFixedTime(BlockHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);

        if(!stateMachine.InputReader.IsBlocking)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            return;
        }

        if(stateMachine.TargeterScript.CurrentTarget == null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }
    }

    public override void ExitState()
    {
        stateMachine.Health.SetInvulnerableBlock(false);
    }
}
