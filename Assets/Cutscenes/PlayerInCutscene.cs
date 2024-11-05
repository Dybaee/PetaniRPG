using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerStateMachine Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    public void ActivatePlayer()
    {
        Player.enabled = true;
    }

    public void DeactivatePlayer()
    {
        Player.enabled = false;
    }
}
