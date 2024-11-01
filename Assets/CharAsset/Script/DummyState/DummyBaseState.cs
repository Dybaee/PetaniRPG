using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DummyBaseState : State
{
    protected DummyStateMachine dummystateMachine;

    public DummyBaseState(DummyStateMachine dummystateMachine)
    {
        this.dummystateMachine = dummystateMachine;
    }
}
