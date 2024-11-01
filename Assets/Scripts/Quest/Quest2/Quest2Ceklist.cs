using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2Ceklist : MonoBehaviour
{
    public GameObject tutorialStatus;

    public GameObject tutorialObj;
    public Animator anim;
    public bool finding = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        if (finding)
        {
            StartCoroutine(AnimDelay());
        }
    }

    public void Find()
    {
        finding = true;
        UpdateStatus();
    }

    IEnumerator AnimDelay()
    {
        tutorialStatus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Ceklist");

        yield return new WaitForSeconds(2.5f);
        tutorialObj.gameObject.SetActive(false);
    }
}
