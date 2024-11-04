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
        Debug.Log("Use left click to hit the dummy");
    }

    private void Update() 
    {
        
    }

    private void Quest2Start()
    {
        // Start quest 2 here
        Debug.Log("Kill some enemy dogs");
    }

    private void Quest3Start()
    {
        // Start quest 3 here
        Debug.Log("Go to your village");
    }

    public void TutorialDummy()
    {
        // Quest 2 muncul, quest 1 ceklis
        Debug.Log("Tutorial complete");
        DummyTutorialWall.SetActive(false);
        Quest2Start();
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
        AreaSawahEnemies -= 1;
        if (AreaSawahEnemies <= 0)
        {
            AreaSawahEnemies = 0;
        }

        if(AreaDesaEnemies == 0)
        {
            // Quest 4 clear if AreaDesaEnemies = 0
            AreaDesaWall.SetActive(false);
            Debug.Log("Area is Cleared");
        }
        else{return; }
    }

    public void BossDied()
    {
        // Quest boss finished, go to main menu
        Debug.Log("Boss is dead");
    }
}
