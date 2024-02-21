using System;
using CookieClickerProject.Common;
using CookieClickerProject.Data;
using UnityEngine;

namespace FortressFableProject.Program.Scripts.Common.Core
{
    public class GameManager: AbstractSingleton<GameManager>
    {
        public DataStorage dataStorage;

        private void Start()
        {
            dataStorage = ScriptableObject.CreateInstance<DataStorage>();
        }
    }
}