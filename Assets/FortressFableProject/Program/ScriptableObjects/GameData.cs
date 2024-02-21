using System;
using System.Collections.Generic;
using UnityEngine;

namespace CookieClickerProject.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    [Serializable]
    public class GameData : ScriptableObject
    {
        public List<UnitBase> units = new ();
        public List<FacilityBase> facilities = new List<FacilityBase>();
        public int wave;
    }
}