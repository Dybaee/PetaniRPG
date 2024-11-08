using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCD : MonoBehaviour
{
    private Animator anim;
    public PotionManager manager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayAnim()
    {
        anim.SetTrigger("Delayed");
    }
}
