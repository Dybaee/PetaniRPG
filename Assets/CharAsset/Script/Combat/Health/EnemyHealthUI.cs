using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private RectTransform HealthUI;

    private HealthData healthData;
    private float decreaseXScale;
    // Start is called before the first frame update
    void Start()
    {
        healthData = GetComponent<HealthData>();
    }

    public void UIHealthDecreaseUpdate(float divideAmount)
    {
        float damageCalculate = healthData.damageAmount / divideAmount;
        decreaseXScale = Mathf.Clamp(HealthUI.localScale.x - damageCalculate, 0f, 1f);

        HealthUI.localScale = new Vector3(decreaseXScale, 1f, 1f);
        HealthUI.anchoredPosition = new Vector2((1 - decreaseXScale) * -HealthUI.rect.width / 2, HealthUI.anchoredPosition.y);
    }

    public void UIHealthZero()
    {
        decreaseXScale = 0f;

        HealthUI.localScale = new Vector3(decreaseXScale, 1f, 1f);
        HealthUI.anchoredPosition = new Vector2((1 - decreaseXScale) * -HealthUI.rect.width / 2, HealthUI.anchoredPosition.y);
    }
}
