using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSavingPlayer : MonoBehaviour
{
    private GameObject Player;
    private void Awake() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SavePos()
    {
        Vector3 playerPosition = Player.transform.position;
        PlayerPrefs.SetFloat("xPos", playerPosition.x);
        PlayerPrefs.SetFloat("yPos", playerPosition.y);
        PlayerPrefs.SetFloat("zPos", playerPosition.z);
        PlayerPrefs.Save();

        Debug.Log("Player position saved: " + playerPosition);
    }

    public void LoadPos()
    {
       Vector3 savedPosition = new Vector3(
            PlayerPrefs.GetFloat("xPos", Player.transform.position.x),
            PlayerPrefs.GetFloat("yPos", Player.transform.position.y),
            PlayerPrefs.GetFloat("zPos", Player.transform.position.z)
        );

        // Move the player to the saved position
        Player.transform.position = savedPosition;

        // Optionally, reset any other player states, like health
        Debug.Log("Player respawned at: " + savedPosition);
    }

    public void DeletePos()
    {
        PlayerPrefs.DeleteAll();
    }
}
