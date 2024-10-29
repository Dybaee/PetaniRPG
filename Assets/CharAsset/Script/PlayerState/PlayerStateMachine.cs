using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController CharController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Targeter TargeterScript { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiverScript { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }
    [field: SerializeField] public AttackDamage AttackDamageScriptL { get; private set; }
    [field: SerializeField] public AttackDamage AttackDamageScriptR { get; private set; }
    [field: SerializeField] public AttackData[] AttackData { get; private set; }

    [field: SerializeField] public int HealValue { get; private set; }
    [field: SerializeField] public float FreelookRunSpeed { get; private set; }
    [field: SerializeField] public float TargetingRunSpeed { get; private set; }
    [field: SerializeField] public float RotationSmoothValue { get; private set; }

    public Transform MainCamTransform { get; private set; }
    // First state when the game is on
    private void Start()
    {
        MainCamTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new PlayerImpactState(this));
    }

    private void HandleDie()
    {
        SwitchState(new PlayerDeadState(this));
    }

    public void SetPlayerPosition(Vector3 position)
    {
        transform.position = position;
    }
}
