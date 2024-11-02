using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    
    public GameObject fPress;
    public GameObject quest3;
    // Start is called before the first frame update
    void Start()
    {
        quest3.SetActive(false);
        fPress.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            fPress.SetActive(true);
            quest3.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        fPress.SetActive(false);
    }
}
