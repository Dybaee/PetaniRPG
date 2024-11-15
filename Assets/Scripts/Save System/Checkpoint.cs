using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnterArea;
    [SerializeField] private Material MaterialOnEnter;
    private Renderer thisRenderer;

    private void Start() 
    {
        thisRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            onEnterArea.Invoke();
        }
    }
}
