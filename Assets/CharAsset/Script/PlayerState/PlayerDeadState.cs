using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeathHash = Animator.StringToHash("Death");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.2f;

    private float timer;

    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void EnterState()
    {
        timer = stateMachine.RespawnTime;
        
        //anim or ragdoll
        stateMachine.Animator.CrossFadeInFixedTime(DeathHash, CrossFadeDuration);
        stateMachine.Health.UIHealthZero();
        //stateMachine.StartCoroutine(stateMachine.DiedPopup.AnimPopup());

        stateMachine.AttackDamageScript.gameObject.SetActive(false);
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        timer -= deltaTime;
        if(timer <= 0)
        {
            timer = 0f;
        }

        if(timer == 0)
        {
            stateMachine.SwitchState(new PlayerRespawnState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}
