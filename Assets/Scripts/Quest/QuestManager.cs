using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Dummy Quest")]
    [SerializeField] private GameObject DummyTutorialWall;
    [SerializeField] private Animator Quest1Anim;
    [SerializeField] private Animator Ceklis1Anim;

    [Header("Sawah Battle Quest")]
    [SerializeField] private int AreaSawahEnemies = 3;
    [SerializeField] private GameObject AreaSawahWall;
    [SerializeField] private Animator Quest2Anim;
    [SerializeField] private Animator Ceklis2Anim;

    [Header("Go to Village Quest")]
    [SerializeField] private Animator Quest3Anim;
    [SerializeField] private Animator Ceklis3Anim;

    [Header("Desa Battle Quest")]
    [SerializeField] private int AreaDesaEnemies = 5;
    [SerializeField] private GameObject AreaDesaWall;
    [SerializeField] private Animator Quest4Anim;
    [SerializeField] private Animator Ceklis4Anim;

    [Header("Find survivor Quest")]
    [SerializeField] private GameObject FindSurvivorWall;
    [SerializeField] private Animator Quest5Anim;
    [SerializeField] private Animator Ceklis5Anim;

    [Header("Bossfight Quest")]
    [SerializeField] private Animator Quest6Anim;
    [SerializeField] private Animator Ceklis6Anim;

    private void Start() 
    {
        DummyTutorialWall.SetActive(true);

        //Quest 1 Here
        Quest1Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Use left click to hit the dummy");
    }

    private void Update() 
    {
        
    }

    public void Quest2Start()
    {
        // Start quest 2 here
        Quest1Anim.gameObject.SetActive(false);
        Quest2Anim.gameObject.SetActive(true);
        Quest2Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Kill some enemy dogs");
    }

    private void Quest3Start()
    {
        // Start quest 3 here
        Quest2Anim.gameObject.SetActive(false);
        Quest3Anim.gameObject.SetActive(true);
        Quest3Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Go to your village");
    }

    public void Quest4Start()
    {
        StartCoroutine(Quest3Coroutine());
    }
    
    private void Quest5Start()
    {
        // Start Quest 5 here
        Quest5Anim.gameObject.SetActive(true);
        Quest5Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Find any survivor");
    }

    public void Quest6Start()
    {
        // Start Quest 6 here
        Quest5Anim.gameObject.SetActive(false);
        Quest6Anim.gameObject.SetActive(true);
        FindSurvivorWall.SetActive(false);
        Quest6Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Kill the enemy boss");
    }

    public void TutorialDummy()
    {
        // Quest 2 muncul, quest 1 ceklis
        Ceklis1Anim.SetTrigger("Ceklist");
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
            StartCoroutine(Quest2Coroutine());
        }
        else{return;}
    }

    public void EnemyDesaDecrease()
    {
        // Quest 4, if enemy dead then Decrease enemy count
        AreaDesaEnemies -= 1;
        if (AreaDesaEnemies <= 0)
        {
            AreaDesaEnemies = 0;
        }

        if(AreaDesaEnemies == 0)
        {
            StartCoroutine(Quest4Coroutine());
        }
        else{return; }
    }

    public void SurvivorFound()
    {
        // Quest 5 Clear
        Ceklis5Anim.SetTrigger("Ceklist");
        Debug.Log("Survivor has found");
    }

    public void BossDied()
    {
        // Quest boss finished, go to main menu
        Ceklis6Anim.SetTrigger("Ceklist");
        Debug.Log("Boss is dead");
    }

    private IEnumerator Quest2Coroutine()
    {
        // Quest 2 clear if AreaSawahEnemies = 0
        AreaSawahWall.SetActive(false);
        Debug.Log("Area is Cleared");
        Ceklis2Anim.SetTrigger("Ceklist");
        yield return new WaitForSeconds(3);

        Quest2Anim.gameObject.SetActive(true);
        Quest3Start();
        yield return null;
    }

    private IEnumerator Quest3Coroutine()
    {
        // Quest 2 clear if AreaSawahEnemies = 0
        Ceklis3Anim.SetTrigger("Ceklist");
        yield return new WaitForSeconds(3);

        // Start Quest 4 here
        Quest3Anim.gameObject.SetActive(false);
        Quest4Anim.gameObject.SetActive(true);
        Quest4Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Eliminate the invaders");
        yield return null;
    }

    private IEnumerator Quest4Coroutine()
    {
        // Quest 4 clear
        Ceklis4Anim.SetTrigger("Ceklist");
        AreaDesaWall.SetActive(false);
        Debug.Log("Area is Cleared");
        yield return new WaitForSeconds(3);

        // Start Quest 4 here
        Quest4Anim.gameObject.SetActive(false);
        Quest5Start();
        yield return null;
    }
}
