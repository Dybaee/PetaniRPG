using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossHPCam : MonoBehaviour
{
    public GameObject healthUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthUI.SetActive(false);
        }
    }
}
