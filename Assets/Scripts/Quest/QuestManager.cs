using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Dummy Quest")]
    [SerializeField] private GameObject DummyTutorialWall;

    [Header("Sawah Battle Quest")]
    [SerializeField] private int AreaSawahEnemies = 3;
    [SerializeField] private GameObject AreaSawahWall;

    [Header("Desa Battle Quest")]
    [SerializeField] private int AreaDesaEnemies = 5;
    [SerializeField] private GameObject AreaDesaWall;

    private void Start() 
    {
        DummyTutorialWall.SetActive(true);

        //Quest 1 Here
        Debug.Log("QUEST : Use left click to hit the dummy");
    }

    private void Update() 
    {
        
    }

    public void Quest2Start()
    {
        // Start quest 2 here
        Debug.Log("QUEST : Kill some enemy dogs");
    }

    private void Quest3Start()
    {
        // Start quest 3 here
        Debug.Log("QUEST : Go to your village");
    }

    public void Quest4Start()
    {
        // Start Quest 4 here
        Debug.Log("QUEST : Eliminate the invaders");
    }
    
    private void Quest5Start()
    {
        // Start Quest 5 here
        Debug.Log("QUEST : Find any survivor");
    }

    public void Quest6Start()
    {
        // Start Quest 6 here
        Debug.Log("QUEST : Kill the enemy boss");
    }

    public void TutorialDummy()
    {
        // Quest 2 muncul, quest 1 ceklis
        Debug.Log("Tutorial complete");
        DummyTutorialWall.SetActive(false);
    }

    public void EnemySawahDecrease()
    {
        // Quest 2, if enemy dead then Decrease enemy count
        AreaSawahEnemies -= 1;
        if (AreaSawahEnemies <= 0)
        {
            AreaSawahEnemies = 0;
        }

        if(AreaSawahEnemies == 0)
        {
            // Quest 2 clear if AreaSawahEnemies = 0
            AreaSawahWall.SetActive(false);
            Debug.Log("Area is Cleared");
            Quest3Start();
        }
        else{return;}
    }

    public void EnemyDesaDecrease()
    {
        // Quest 2, if enemy dead then Decrease enemy count
        AreaDesaEnemies -= 1;
        if (AreaDesaEnemies <= 0)
        {
            AreaDesaEnemies = 0;
        }

        if(AreaDesaEnemies == 0)
        {
            // Quest 4 clear if AreaDesaEnemies = 0
            AreaDesaWall.SetActive(false);
            Debug.Log("Area is Cleared");
            Quest5Start();
        }
        else{return; }
    }

    public void SurvivorFound()
    {
        // Quest 5 Clear
        Debug.Log("Survivor has found");
    }

    public void BossDied()
    {
        // Quest boss finished, go to main menu
        Debug.Log("Boss is dead");
    }
}
