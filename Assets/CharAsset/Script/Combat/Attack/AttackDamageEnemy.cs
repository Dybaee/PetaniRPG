using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackDamageEnemy : MonoBehaviour
{
    [SerializeField] private Collider ThisGameobjectCollider;
    [SerializeField] private SphereCollider ThisComponentCollider;

    private List<Collider> alreadyCollidedWith = new List<Collider>();
    private int damage;
    private float knockbackValue;

    private void Start()
    {
        if(ThisComponentCollider == null)
        {
            return;
        }
    }

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == ThisGameobjectCollider && other.gameObject.tag == "Enemy") { return; }
        if(other == ThisComponentCollider) { return; }

        if (alreadyCollidedWith.Contains(other)) { return; }

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
