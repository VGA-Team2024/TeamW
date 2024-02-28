using System.IO;
using CookieClickerProject.Data;
using UnityEngine;

namespace CookieClickerProject.Common
{
    public class SaveAndLoad : AbstractSingleton<SaveAndLoad>
    {
        protected override bool UseDontDestroyOnLoad => true;

        public StorageData StorageData { get; private set; }
        private PlayerData PlayerData { get; set; }
        private GameData GameData { get; set; }
        private AudioData AudioData { get; set; }

        private void Awake()
        {
            LoadGame();
        }

        /// <summary>
        /// ゲーム一時停止時にセーブ
        /// </summary>
        /// <param name="pauseStatus"></param>
        public void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveGame();
            }
        }

        /// <summary>
        /// ゲーム終了時にセーブ
        /// </summary>
        public void OnApplicationQuit()
        {
            SaveGame();
        }

        /// <summary>
        /// ゲームデータをセーブ
        /// </summary>
        public void SaveGame()
        {
            StorageData storageData = new StorageData
            {
                PlayerData = this.PlayerData,
                GameData = this.GameData,
                AudioData = this.AudioData
            };
            string data = JsonUtility.ToJson(storageData, true);
            string filePath = Path.Combine(Application.dataPath, "gameSave.json");
            File.WriteAllText(filePath, data);
        }

        /// <summary>
        /// ゲームデータをロード
        /// </summary>
        public void LoadGame()
        {
            string filePath = Path.Combine(Application.dataPath, "gameSave.json");
            if (File.Exists(filePath))
            {
                // ファイルが存在する場合、セーブデータをロード
                string data = File.ReadAllText(filePath);
                StorageData = JsonUtility.FromJson<StorageData>(data); // 直接プロパティにセット

                // ロードしたデータがnullでないことを確認し、必要に応じてデフォルトのインスタンスを生成
                AudioData = StorageData.AudioData ?? new AudioData();
                PlayerData = StorageData.PlayerData ?? new PlayerData();
                GameData = StorageData.GameData ?? new GameData();
            }
            else
            {
                // ファイルが存在しない場合、新規にPlayerDataとGameDataとAudioDataを生成
                AudioData = new AudioData();
                PlayerData = new PlayerData();
                GameData = new GameData();
                // StorageData プロパティにもこれらをセット
                StorageData = new StorageData { AudioData = AudioData, PlayerData = PlayerData, GameData = GameData };

                // 新規作成したデータをセーブして、次回のゲーム起動時に利用可能にする
                SaveGame();
            }
        }
    }
}