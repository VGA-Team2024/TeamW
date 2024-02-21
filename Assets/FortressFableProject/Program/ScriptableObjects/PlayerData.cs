using UnityEngine;
using UniRx;

namespace CookieClickerProject.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        public int totalMoney;
    }
}