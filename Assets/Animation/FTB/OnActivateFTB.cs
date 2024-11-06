using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActivateFTB : MonoBehaviour
{
    private float timer = 12f;
    private Animator thisAnim;
    // Start is called before the first frame update
    void Start()
    {
        thisAnim = GetComponent<Animator>();

        thisAnim.SetTrigger("FTB");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }

        if(timer == 0)
        {
            thisAnim.SetTrigger("Light");
            gameObject.SetActive(false);
        }
    }
}
