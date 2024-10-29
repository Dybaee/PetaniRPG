using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveGame(PlayerStateMachine playerState)
    {
        GameData data = new GameData();
        playerState.SaveData(ref data);

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
        Debug.Log("Game Saved: " + json);
    }


    public static void LoadGame(PlayerStateMachine playerState)
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string json = PlayerPrefs.GetString("GameData");
            GameData data = JsonUtility.FromJson<GameData>(json);
            playerState.LoadData(data);
            Debug.Log("Game Loaded: " + json);
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }
}
