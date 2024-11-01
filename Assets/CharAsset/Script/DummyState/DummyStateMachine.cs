using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }

    private void Start()
    {
        SwitchState(new DummyIdleState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new DummyImpactState(this));
    }
}