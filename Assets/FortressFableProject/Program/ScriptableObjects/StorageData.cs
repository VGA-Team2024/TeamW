namespace CookieClickerProject.Data
{
    [System.Serializable]
    public class StorageData
    {
        public PlayerData PlayerData = new();
        public GameData GameData = new();
        public AudioData AudioData = new();
    }
}