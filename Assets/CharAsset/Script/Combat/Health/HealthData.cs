using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private int currentHealth;
    private bool isHitBlocked;

    public bool isDead => currentHealth == 0;

    public event Action OnTakeDamage;
    public event Action OnDie;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetInvulnerableBlock(bool isHitBlocked)
    {
        this.isHitBlocked = isHitBlocked;
    }

    public void DealDamage(int damageAmount)
    {
        if(currentHealth <= 0) { return; }

        if (isHitBlocked) { return; }

        currentHealth -= damageAmount;  

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        OnTakeDamage?.Invoke();

        if(currentHealth == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(currentHealth);
    }
}