using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPopup1 : MonoBehaviour
{
    public GameObject qbar;
    private bool questTriggered = false;

    void Start()
    {
        qbar.SetActive(false); 
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !questTriggered)
        {
            qbar.SetActive(true);
            questTriggered = true;
        }
    }
}
