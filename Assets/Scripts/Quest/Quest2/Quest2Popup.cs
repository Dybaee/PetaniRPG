using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2Popup : MonoBehaviour
{
    public GameObject qbar;
    public GameObject previousQuest;
    private bool questTriggered = false;

    void Start()
    {
        qbar.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (previousQuest.activeSelf && !questTriggered)
            {
                qbar.SetActive(false);
            }
            else if (!questTriggered)
            {
                qbar.SetActive(true);
                questTriggered = true;
            }
        }
    }
}
