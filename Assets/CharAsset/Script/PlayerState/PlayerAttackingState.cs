using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;
    private bool alreadyAppliedForce = false;
    private AttackData attack;
    public PlayerAttackingState(PlayerStateMachine stateMachine, int AttackIndex) : base(stateMachine)
    {
        stateMachine.InputReader.ConsumeIsAttacking();
        attack = stateMachine.AttackData[AttackIndex];
    }

    public override void EnterState()
    {
        stateMachine.SFXAudio.PlayOneShot(stateMachine.SoundEffect[2]);
        stateMachine.AttackDamageScript.SetDamage(attack.Damage, attack.Knockback);
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        MoveWithoutMotion(deltaTime);
        FaceToTarget();

        float normalizedTime = GetNormalizedTime();

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if(normalizedTime >= attack.ForceTime)
            {
                TryApplyForce();
            }

            if(stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
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

        previousFrameTime = normalizedTime;
    }

    public override void ExitState()
    {
        
    }

    private void TryComboAttack(float normalizedTime)
    {
        if(attack.ComboStateIndex == -1) { return; }

        if(normalizedTime < attack.ComboAttackTime) { return; }

        stateMachine.SwitchState(new PlayerAttackingState(stateMachine, attack.ComboStateIndex));
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) { return; }
        stateMachine.ForceReceiverScript.AddForce(stateMachine.transform.forward * attack.Force);

        alreadyAppliedForce = true;
    }

    private float GetNormalizedTime()
    {
        AnimatorStateInfo currentInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = stateMachine.Animator.GetNextAnimatorStateInfo(0);

        if (stateMachine.Animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if(!stateMachine.Animator.IsInTransition(0) && currentInfo.IsTag("Attack")) 
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}