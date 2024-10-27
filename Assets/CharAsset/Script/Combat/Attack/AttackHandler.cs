using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponHitbox;
    
    public void EnableHitbox()
    {
        foreach (var weapon in weaponHitbox)
        {
            weapon.SetActive(true);
        }     
    }

    public void DisableHitbox()
    {
        foreach (var weapon in weaponHitbox)
        {
            weapon.SetActive(false);
        }
    }
}