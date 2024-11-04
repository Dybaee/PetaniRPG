using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private int EnemyCount = 3;

    private void Start() 
    {
        
    }

    private void Update() 
    {
        if(EnemyCount == 0)
        {
            //Quest area clear here
            Debug.Log("Area is Cleared");
        }    
    }

    public void BossDied()
    {
        // Quest boss mati disini
        Debug.Log("Boss is dead");
    }

    public void EnemyDecrease()
    {
        EnemyCount -= 1;
        if (EnemyCount <= 0)
        {
            EnemyCount = 0;
        }
    }
}
