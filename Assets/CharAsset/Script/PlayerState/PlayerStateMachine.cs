using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStateMachine : StateMachine, IDataPersistence
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController CharController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Targeter TargeterScript { get; private set; }
    [field: SerializeField] public InDialogue DialogueTriggerScript { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiverScript { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public AttackDamage AttackDamageScriptL { get; private set; }
    [field: SerializeField] public AttackDamage AttackDamageScriptR { get; private set; }
    [field: SerializeField] public AttackData[] AttackData { get; private set; }
    [field: SerializeField] public AudioClip[] AudioClips { get; private set; }
    [field: SerializeField] public int HealValue { get; private set; }
    [field: SerializeField] public float RespawnTime { get; private set; }
    [field: SerializeField] public float FreelookRunSpeed { get; private set; }
    [field: SerializeField] public float TargetingRunSpeed { get; private set; }
    [field: SerializeField] public float RotationSmoothValue { get; private set; }

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
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
        Health.OnHeal -= HandleHeal;
        Health.OnRespawn -= HandleRespawn;
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

    public void LoadData(GameData data)
    {
        if (data != null)
        {
            StartCoroutine(PlacePlayerAfterSceneLoad(data.playerPosition));
        }
    }

    private IEnumerator PlacePlayerAfterSceneLoad(Vector3 savedPosition)
    {
        // Dikasih delay gegara terlalu cepet load scene
        yield return new WaitForSeconds(0.3f);

        this.transform.position = savedPosition;
    }

    public void SaveData(ref GameData data)
    {
        if (data != null) 
        {
            data.playerPosition = this.transform.position;
        }
    }

}
