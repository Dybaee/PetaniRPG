using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private int currentIndex = -1;
    public List<GameObject> currentTexts;


    [Header("Dummy Quest")]
    [SerializeField] private GameObject DummyTutorialWall;
    [SerializeField] private Animator Quest1Anim;
    [SerializeField] private Animator Ceklis1Anim;

    [Header("Sawah Battle Quest")]
    [SerializeField] private int AreaSawahEnemies = 3;
    [SerializeField] private GameObject AreaSawahWall;
    [SerializeField] private List<GameObject> TextQuest2;
    [SerializeField] private Animator Quest2Anim;
    [SerializeField] private Animator Ceklis2Anim;

    [Header("Go to Village Quest")]
    [SerializeField] private Animator Quest3Anim;
    [SerializeField] private Animator Ceklis3Anim;
    [SerializeField] private List<GameObject> TextQuest3;

    [Header("Desa Battle Quest")]
    [SerializeField] private int AreaDesaEnemies = 5;
    [SerializeField] private GameObject AreaDesaWall;
    [SerializeField] private Animator Quest4Anim;
    [SerializeField] private Animator Ceklis4Anim;
     [SerializeField] private List<GameObject> TextQuest4;

    [Header("Find survivor Quest")]
    [SerializeField] private GameObject FindSurvivorWall;
    [SerializeField] private Animator Quest5Anim;
    [SerializeField] private Animator Ceklis5Anim;
    [SerializeField] private List<GameObject> TextQuest5;

    [Header("Bossfight Quest")]
    [SerializeField] private Animator Quest6Anim;
    [SerializeField] private Animator Ceklis6Anim;
    [SerializeField] private List<GameObject> TextQuest6;
    [SerializeField] private GameObject CutsceneEnd;

    [Header("After Boss Quest")]
    [SerializeField] private List<GameObject> TextQuest7;

    private void Start() 
    {
        DummyTutorialWall.SetActive(true);

        InsertContents(TextQuest2, ref currentTexts);

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

        StartCoroutine(ActivateTextQuest());
    }

    private void Quest3Start()
    {
        // Start quest 3 here
        ReplaceContents(TextQuest3, ref currentTexts);
        
        Quest3Anim.gameObject.SetActive(true);
        Quest3Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Go to your village");

        StartCoroutine(ActivateTextQuest());
    }

    public void Quest4Start()
    {
        ReplaceContents(TextQuest4, ref currentTexts);

        StartCoroutine(Quest3Coroutine());
    }
    
    private void Quest5Start()
    {
        // Start Quest 5 here
        ReplaceContents(TextQuest5, ref currentTexts);

        Quest5Anim.gameObject.SetActive(true);
        Quest5Anim.SetTrigger("Popup");
        Debug.Log("QUEST : Find any survivor");

        StartCoroutine(ActivateTextQuest());
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

    public void Quest6Text()
    {
        ReplaceContents(TextQuest6, ref currentTexts);
        StartCoroutine(ActivateTextQuest());
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
        ReplaceContents(TextQuest7, ref currentTexts);

        // Quest boss finished, go to main menu
        Ceklis6Anim.SetTrigger("Ceklist");
        Debug.Log("Boss is dead");

        StartCoroutine(EndGame());
    }

    private IEnumerator Quest2Coroutine()
    {
        // Quest 2 clear if AreaSawahEnemies = 0
        AreaSawahWall.SetActive(false);
        Debug.Log("Area is Cleared");
        Ceklis2Anim.SetTrigger("Ceklist");
        yield return new WaitForSeconds(3);

        Quest2Anim.gameObject.SetActive(false);
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

        StartCoroutine(ActivateTextQuest());
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

    private IEnumerator EndGame()
    {
        // Quest 6 clear
        StartCoroutine(ActivateTextQuest());

        yield return new WaitForSeconds(8);

        CutsceneEnd.SetActive(true);

        yield return null;
    }

    void InsertContents(List<GameObject> source, ref List<GameObject> target)
    {
        // Ensure the target array is large enough
        while (target.Count < source.Count)
        {
            target.Add(null);
        }

        for (int i = 0; i < source.Count; i++)
        {
            target[i] = source[i]; // Copy each element from source to target
        }
    }

    void ReplaceContents(List<GameObject> replacement, ref List<GameObject> target)
    {
        // Ensure the target array is large enough
        while (target.Count < replacement.Count)
        {
            target.Add(null);
        }

        for (int i = 0; i < replacement.Count; i++)
        {
            target[i] = replacement[i]; // Replace each element in target with the replacement
        }
    }

    private IEnumerator ActivateTextQuest()
    {
        for (int i = 0; i < currentTexts.Count; i++)
        {
            // Deactivate the previous GameObject if one is active
            if (currentIndex >= 0 && currentIndex < currentTexts.Count)
            {
                currentTexts[currentIndex].SetActive(false);
            }
            
            // Move to the next index
            currentIndex++;

            // Activate the current GameObject
            currentTexts[currentIndex].SetActive(true);

            // Wait for the specified interval before the next activation
            yield return new WaitForSeconds(3f);
        }

        // Optionally, deactivate the last GameObject after the loop finishes
        if (currentIndex >= 0 && currentIndex < currentTexts.Count)
        {
            currentTexts[currentIndex].SetActive(false);
            currentIndex = -1;
        }
    }
}
