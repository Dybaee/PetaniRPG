using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Ceklist : MonoBehaviour
{

    public GameObject tutorialStatus;
    public GameObject tutorialObj;
    public Animator anim;
    public bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Killed()
    {
        kill = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        if (kill) 
        {
            StartCoroutine(AnimDelay());
        }
    }

    IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetTrigger("Ceklist");

        yield return new WaitForSeconds(2.5f);
        tutorialObj.gameObject.SetActive(false);
    }
}
