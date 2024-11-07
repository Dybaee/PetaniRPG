using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public bool EnemyStand { get; private set; }
    [field: SerializeField] public string EnemyWaypointName { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public float PlayerDetection { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public AttackDamageEnemy Weapon { get; private set; }
    [field: SerializeField] public HealthData Health { get; private set; }
    [field: SerializeField] public Target Target { get; private set; }
    [field: SerializeField] public Quest1Ceklist quest1 { get; private set; }
    [field: SerializeField] public EnemyHealthUI HealthUI { get; private set; }
    [field: SerializeField] public float DivideAmount { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public int AttackKnockback { get; private set; }
    [field: SerializeField] public List<Transform> wayPoints { get; private set; }

    [SerializeField] private UnityEvent onEnemyKilled;

    private WaypointList EnemyWaypoint;
    public HealthData Player { get; private set; }

    private void Start()
    {
        //menemukan player
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthData>();

        //agar ai tidak menggerakkan enemy(agar bisa modify lebih jauh) 
        Agent.updatePosition = false;
        Agent.updateRotation = false;


        if(EnemyStand)
        {
            SwitchState(new EnemyIdleState(this));
        }
        else
        {
            EnemyWaypoint = GameObject.FindGameObjectWithTag(EnemyWaypointName).GetComponent<WaypointList>();
            
            while (wayPoints.Count < EnemyWaypoint.wayPointsSet.Count)
            {
                wayPoints.Add(null);
            }

            for (int i = 0; i < EnemyWaypoint.wayPointsSet.Count; i++)
            {
                wayPoints[i] = EnemyWaypoint.wayPointsSet[i]; // Replace each element in target with the replacement
            }

            SwitchState(new EnemyPatrolState(this));
        }
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
        SwitchState(new EnemyImpactState(this));
    }

    private void HandleDie()
    {
        //StartCoroutine(EnemyDie());
        onEnemyKilled.Invoke();
        SwitchState(new EnemyDeadState(this));
    }

    IEnumerator EnemyDie()
    {
        quest1.OnKilled();
        SwitchState(new EnemyDeadState(this));
        yield break;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerDetection);
    }

    
}