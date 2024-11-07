using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionCheck : MonoBehaviour
{
    public event Action OnEnemyEnterCollider;
    public event Action OnEnemyExitCollider;
    private void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            OnEnemyEnterCollider?.Invoke();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            OnEnemyExitCollider?.Invoke();
        }
    }
}
