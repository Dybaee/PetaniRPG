using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPCTrigger : MonoBehaviour
{

    private Quest2Ceklist quest2;
    public GameObject fPress;

    // Start is called before the first frame update
    void Start()
    {
        fPress.SetActive(false);
        quest2 = GetComponent<Quest2Ceklist>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fPress.SetActive(true);
            quest2.Find();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fPress.SetActive(false);
        }
    }
}
