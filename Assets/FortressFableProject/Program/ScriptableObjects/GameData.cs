using System;
using System.Collections.Generic;

namespace CookieClickerProject.Data
{
    [Serializable]
    public class GameData
    {
        public List<Upgrade> availableUpgrades;
        public List<Producer> availableProducers;
        public List<ShopItem> shopItems;
    }

    [Serializable]
    public class ShopItem
    {
        public string itemName;
        public int cost;

        public string effect;
        // その他の必要なフィールド...
    }

    [Serializable]
    public class Upgrade
    {
        public string upgradeName;
        public int cost;

        public string effect;
        // その他の必要なフィールド...
    }


    [Serializable]
    public class Producer
    {
        public string producerName;
        public int cost;

        public int productionRate;
        // その他の必要なフィールド...
    }
}