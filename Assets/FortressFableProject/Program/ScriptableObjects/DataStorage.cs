using System;
using System.IO;
using UnityEngine;

namespace CookieClickerProject.Data
{
    public class DataStorage : ScriptableObject
    {
        private PlayerData _playerData;
        private GameData _gameData;

        private void Awake()
        {
            _playerData = ScriptableObject.CreateInstance<PlayerData>();
            _gameData = ScriptableObject.CreateInstance<GameData>();
            LoadGame();
        }

        public void ResetGame()
        {
            
        }


        // 今後必要になるかもしれないセーブとロード
        public void SaveGame()
        {
            string data = JsonUtility.ToJson(_playerData, true);
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            File.WriteAllText(filePath, data);
        }

        public void LoadGame()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                JsonUtility.FromJsonOverwrite(data, _playerData);
            }
        }

    }
}