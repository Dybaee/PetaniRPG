using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveGame(PlayerStateMachine playerState)
    {
        GameData data = new GameData();
        // playerState.SaveData(ref data);

        string json = JsonUtility.ToJson(data);
        //PlayerSave.SetString("GameData", json);
        //PlayerSave.Save();
        Debug.Log("Game Saved: " + json);
    }


    public static void LoadGame(PlayerStateMachine playerState)
    {
        // if (PlayerSave.HasKey("GameData"))
        // {
        //     string json = PlayerSave.GetString("GameData");
        //     GameData data = JsonUtility.FromJson<GameData>(json);
        //     playerState.LoadData(data);
        //     Debug.Log("Game Loaded: " + json);
        // }
        // else
        // {
        //     Debug.Log("No saved game data found.");
        // }
    }
}
