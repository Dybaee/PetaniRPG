using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStateMachine : StateMachine
{
    [field: Header("Properties for Components")]
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController CharController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Targeter TargeterScript { get; private set; }
    [field: SerializeField] public InDialogue DialogueTriggerScript { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiverScript { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }
    [field: SerializeField] public EnemyPositionCheck EnemyPosition { get; private set; }
    [field: SerializeField] public AudioSource SFXAudio { get; private set; }
    [field: SerializeField] public AttackDamage AttackDamageScript { get; private set; }

    [field: Header("Array Data")]
    [field: SerializeField] public AttackData[] AttackData { get; private set; }
    [field: SerializeField] public AudioClip[] SoundEffect { get; private set; }

    [field: Header("Values Settings")]
    [field: SerializeField] public int HealValue { get; private set; }
    [field: SerializeField] public float RespawnTime { get; private set; }
    [field: SerializeField] public float FreelookRunSpeed { get; private set; }
    [field: SerializeField] public float TargetingRunSpeed { get; private set; }
    [field: SerializeField] public float RotationSmoothValue { get; private set; }

    [field: Header("Unity Events")]
    [SerializeField] private UnityEvent onPlayerHeal;
    [SerializeField] private UnityEvent onPlayerDead;
    [SerializeField] private UnityEvent onPlayerRespawn;

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
        Health.OnHeal += HandleHeal;
        Health.OnRespawn += HandleRespawn;
        EnemyPosition.OnEnemyEnterCollider += HandleEnemyEnterCollider;
        EnemyPosition.OnEnemyExitCollider += HandleEnemyExitCollider;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
        Health.OnHeal -= HandleHeal;
        Health.OnRespawn -= HandleRespawn;
        EnemyPosition.OnEnemyEnterCollider -= HandleEnemyEnterCollider;
        EnemyPosition.OnEnemyExitCollider -= HandleEnemyExitCollider;
    }

    private void HandleEnemyEnterCollider()
    {
        Health.SetCanDamageBlock(true);
    }

    private void HandleEnemyExitCollider()
    {
        Health.SetCanDamageBlock(false);
    }

    private void HandleTakeDamage()
    {
        SwitchState(new PlayerImpactState(this));
    }

    private void HandleDie()
    {
        onPlayerDead?.Invoke();
        SwitchState(new PlayerDeadState(this));
    }

    private void HandleHeal()
    {
        onPlayerHeal?.Invoke();
    }

    private void HandleRespawn()
    {
        onPlayerRespawn?.Invoke();
    }
}
