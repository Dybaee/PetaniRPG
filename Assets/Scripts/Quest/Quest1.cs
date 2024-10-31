using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public GameObject qbar; 

    void Start()
    {
        qbar.SetActive(false); 
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            qbar.SetActive(true); 
        }
    }
}
