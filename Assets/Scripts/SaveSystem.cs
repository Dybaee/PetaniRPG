using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Vector3 respawnPoint;
    public string CheckpointTag = "Checkpoint";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CheckpointTag)) 
        {
            respawnPoint = other.transform.position;
            
        }
    }

    void RespawnPlayer()
    {
        // Respawn player terakhir cp
        transform.position = respawnPoint;
    }

    void PlayerDied()
    {
        RespawnPlayer();
    }

    public void SaveCP()
    {
        PlayerPrefs.SetFloat("RespawnX", respawnPoint.x);
        PlayerPrefs.SetFloat("RespawnY", respawnPoint.y);
        PlayerPrefs.SetFloat("RespawnZ", respawnPoint.z);
        PlayerPrefs.Save();
    }

    public void LoadCP()
    {
        
        if (PlayerPrefs.HasKey("RespawnX"))
        {
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");
            respawnPoint = new Vector3(x, y, z);
            transform.position = respawnPoint; // Set player terakhir CP
        }
        else
        {
            respawnPoint = transform.position;
        }
    }

    public void LoadSave()
    {
        LoadCP();
    }
}
