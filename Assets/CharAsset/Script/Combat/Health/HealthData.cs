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
    public int currentHealChances;
    public int damageAmount { get; private set; }
    
    private bool IsCanDamage = false;
    private bool isHitBlocked;
    private float XScale;
    private float healValue;

    public bool isDead => currentHealth == 0;

    public event Action OnTakeDamage;
    public event Action OnDie;
    public event Action OnRespawn;
    public event Action OnHeal;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject HealthGO = GameObject.FindGameObjectWithTag("HealthUI");
        HealthUI = HealthGO.GetComponent<RectTransform>();

        currentHealth = maxHealth;
        currentHealChances = HealChances;
    }

    private void FixedUpdate() 
    {
        // if(currentHealth == maxHealth)
        // {
        //     HealthUI.localScale = new Vector3(1f, 1f, 1f);
        //     HealthUI.localPosition = new Vector3(0, 0, 0 );
        // }
    }

    public void SetInvulnerableBlock(bool isHitBlocked)
    {
        this.isHitBlocked = isHitBlocked;
    }

    public void SetCanDamageBlock(bool isCanDamage)
    {
        this.IsCanDamage = isCanDamage;
    }

    public void DealDamage(int damageAmount)
    {
        this.damageAmount = damageAmount;
        if(currentHealth <= 0) { return; }

        if(isHitBlocked && !IsCanDamage) { return; }

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

        //Debug.Log(currentHealth);
    }

    public void HealSystem(int healValue)
    {
        this.healValue = healValue;
        if (currentHealth <= 0) { return; }       
        currentHealth += healValue;

        OnHeal?.Invoke();
        //Debug.Log(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;

        HealthUI.localScale = new Vector3(1f, 1f, 1f);
        HealthUI.localPosition = new Vector3(0, 0, 0 );

        currentHealChances = HealChances;

        OnRespawn?.Invoke();
    }

    public void UIHealthDecreaseUpdate()
    {
        float damageCalculate = damageAmount / 100f;
        XScale = Mathf.Clamp(HealthUI.localScale.x - damageCalculate, 0f, 1f);

        HealthUI.localScale = new Vector3(XScale, 1f, 1f);
        HealthUI.anchoredPosition = new Vector2((1 - XScale) * -HealthUI.rect.width / 2, HealthUI.anchoredPosition.y);
    }

    public void UIHealthIncreaseUpdate()
    {
        float damageCalculate = healValue / 100f;
        XScale = Mathf.Clamp(HealthUI.localScale.x + damageCalculate, 0f, 1f);

        HealthUI.localScale = new Vector3(XScale, 1f, 1f);
        HealthUI.anchoredPosition = new Vector2((1 - XScale) * -HealthUI.rect.width / 2, HealthUI.anchoredPosition.y);
    }

    public void UIHealthZero()
    {
        XScale = 0f;

        HealthUI.localScale = new Vector3(XScale, 1f, 1f);
        HealthUI.anchoredPosition = new Vector2((1 - XScale) * -HealthUI.rect.width / 2, HealthUI.anchoredPosition.y);
    }
}
