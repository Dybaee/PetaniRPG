using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private RectTransform HealthUI;

    [field: SerializeField] public int currentHealth { get; private set; }
    public int HealChances;

    private bool isHitBlocked;
    private int damageAmount;
    private float decreaseXScale;

    public bool isDead => currentHealth == 0;

    public event Action OnTakeDamage;
    public event Action OnDie;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject HealthGO = GameObject.FindGameObjectWithTag("HealthUI");
        HealthUI = HealthGO.GetComponent<RectTransform>();

        currentHealth = maxHealth;
    }

    public void SetInvulnerableBlock(bool isHitBlocked)
    {
        this.isHitBlocked = isHitBlocked;
    }

    public void DealDamage(int damageAmount)
    {
        this.damageAmount = damageAmount;
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

    public void HealSystem(int healValue)
    {
        if (currentHealth <= 0) { return; }
        currentHealth += healValue;

        Debug.Log(currentHealth);
    }

    public void UIHealthDecreaseUpdate()
    {
        float damageCalculate = damageAmount / 100f;
        decreaseXScale = HealthUI.localScale.x - damageCalculate;
        HealthUI.transform.localScale = new Vector3(decreaseXScale, 1f, 1f);
    }

    public void UIHealthIncreaseUpdate()
    {
        float damageCalculate = damageAmount / 100f;
        decreaseXScale = HealthUI.localScale.x + damageCalculate;
        HealthUI.transform.localScale = new Vector3(decreaseXScale, 1f, 1f);
    }
}