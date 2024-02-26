using System.IO;
using CookieClickerProject.Data;
using UnityEngine;

namespace FortressFableProject.Common
{
    public class SaveAndLoad : MonoBehaviour
    {
        public DataStorage dataStorage;

        private void OnEnable()
        {
            dataStorage = ScriptableObject.CreateInstance<DataStorage>();
            LoadGame();
        }

        public void SaveGame()
        {
            SaveData saveData = new SaveData
            {
                playerData = dataStorage.playerData,
                gameData = dataStorage.gameData
            };
            string data = JsonUtility.ToJson(saveData, true);
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            File.WriteAllText(filePath, data);
        }

        public void LoadGame()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            if (!File.Exists(filePath)) return;
            string data = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(data);
            JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(saveData.playerData), dataStorage.playerData);
            JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(saveData.gameData), dataStorage.gameData);
        }
    }
}