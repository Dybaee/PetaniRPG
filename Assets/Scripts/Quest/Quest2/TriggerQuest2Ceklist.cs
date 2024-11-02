using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuest2Ceklist : MonoBehaviour
{

    [field: SerializeField] public Quest2Ceklist quest2 { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        quest2.finding = true;
        quest2.Find();
    }
}
