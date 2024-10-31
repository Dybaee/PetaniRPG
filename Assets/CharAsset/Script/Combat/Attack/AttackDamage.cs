using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private Collider ThisGameobjectCollider;

    private List<Collider> alreadyCollidedWith = new List<Collider>();
    private int damage;
    private float knockbackValue;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == ThisGameobjectCollider) { return; }

        if(alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if(other.TryGetComponent<HealthData>(out HealthData health))
        {
            health.DealDamage(damage);
        }

        if(other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 knockbackDirection = (other.transform.position - ThisGameobjectCollider.transform.position).normalized;
            forceReceiver.AddForce(knockbackDirection * knockbackValue);
        }
    }

    public void SetDamage(int damage, float knockback)
    {
        this.damage = damage;
        this.knockbackValue = knockback;
    }
}