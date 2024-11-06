using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSavingPlayer : MonoBehaviour
{
    private Transform Player;
    private void Awake() 
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    public void SavePos()
    {
        PlayerPrefs.SetFloat("xPos", Player.position.x);
        PlayerPrefs.SetFloat("yPos", Player.position.y);
        PlayerPrefs.SetFloat("zPos", Player.position.z);
    }

    public void LoadPos()
    {
        float playerX = PlayerPrefs.GetFloat("xPos");
        float playerY = PlayerPrefs.GetFloat("yPos");
        float playerZ = PlayerPrefs.GetFloat("zPos");

        Player.position = new Vector3(playerX, playerY, playerZ); 
    }
}
