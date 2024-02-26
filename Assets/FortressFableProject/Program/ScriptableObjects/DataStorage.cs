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
    }
}