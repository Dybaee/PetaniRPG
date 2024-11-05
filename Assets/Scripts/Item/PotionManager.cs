using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public TextMeshProUGUI potionCountText; 
    
    public void UpdatePotion(int currentCount)
    {
        potionCountText.text = currentCount.ToString();
    }
}
