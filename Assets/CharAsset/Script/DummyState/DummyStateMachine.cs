using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DummyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }
    [field: SerializeField] public QuestTutorial questTutorial { get; private set; }

    [SerializeField] private UnityEvent GoToNextQuest;

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
        if (Health.currentHealth <= 1900)
        {
            //questTutorial.OnHit();
            GoToNextQuest?.Invoke();
        }

        SwitchState(new DummyImpactState(this));
    }
}