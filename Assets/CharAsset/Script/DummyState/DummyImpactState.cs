using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyImpactState : DummyBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("GetHit");

    private const float CrossFadeDuration = 0.2f;
    private float duration = 2f;
    public DummyImpactState(DummyStateMachine dummystateMachine) : base(dummystateMachine)
    {
    }

    public override void EnterState()
    {
        dummystateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void UpdateState(float deltaTime)
    {
        duration -= deltaTime;
        if (duration <= 0f)
        {
            dummystateMachine.SwitchState(new DummyIdleState(dummystateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}
