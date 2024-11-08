using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public TextMeshProUGUI potionCountText; 
    [SerializeField] private float HealCount = 5f;
    private float currentHealCount;
    [SerializeField] private DelayedCD delayAnim;
    
    private void Start() 
    {
        currentHealCount = HealCount;
    }

    private void LateUpdate()
    {
        potionCountText.text = currentHealCount.ToString();
    }

    public void DecreaseUI()
    {
        currentHealCount -= 1;
    }

    public void ResetHealcount()
    {
        currentHealCount = HealCount;
    }
}
