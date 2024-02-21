using System;
using System.IO;
using CookieClickerProject.Data;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerData playerData;
    public GameData gameData;
}

namespace CookieClickerProject.Data
{
    public class DataStorage : ScriptableObject
    {
        public PlayerData playerData;
        public GameData gameData;

        private void OnEnable()
        {
            playerData = ScriptableObject.CreateInstance<PlayerData>();
            gameData = ScriptableObject.CreateInstance<GameData>();
            LoadGame();
        }

        public void SaveGame()
        {
            SaveData saveData = new SaveData
            {
                playerData = this.playerData,
                gameData = this.gameData
            };
            string data = JsonUtility.ToJson(saveData, true);
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            File.WriteAllText(filePath, data);
        }

        public void LoadGame()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                SaveData saveData = JsonUtility.FromJson<SaveData>(data);
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(saveData.playerData), playerData);
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(saveData.gameData), gameData);
            }
        }
    }
}