using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Ceklist : MonoBehaviour
{
    private EnemyStateMachine enemyDead;

    public GameObject tutorialStatus;

    public GameObject tutorialObj;
    public Animator anim;
    public bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyDead = GetComponent<EnemyStateMachine>();
    }

    void Update()
    {
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        if (kill)
        {
            StartCoroutine(AnimDelay());
        }
    }

    public void OnKilled()
    {
        kill = true;
        UpdateStatus();
    }

    IEnumerator AnimDelay()
    {
        tutorialStatus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Ceklist");

        yield return new WaitForSeconds(5.5f);
        tutorialObj.gameObject.SetActive(false);
    }
}
