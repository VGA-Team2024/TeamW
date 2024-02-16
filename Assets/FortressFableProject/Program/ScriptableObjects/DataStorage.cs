using System;
using System.IO;
using UnityEngine;

namespace CookieClickerProject.Data
{
    public class DataStorage : MonoBehaviour
    {
        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = ScriptableObject.CreateInstance<PlayerData>();
            LoadGame();
        }

        public void ResetGame()
        {
            _playerData.TotalCookies = 0;
            _playerData.CookiesPerClick = 1;
            _playerData.CookiesPerSecond = 0;
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