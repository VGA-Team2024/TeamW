using UnityEngine;

namespace CookieClickerProject.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int totalCookies; // 総クッキー数
        [SerializeField] private int cookiesPerClick; // クリックごとのクッキー数
        [SerializeField] private int cookiesPerSecond; // 1秒ごとのクッキー数


        public int TotalCookies
        {
            get => totalCookies;
            set => totalCookies = value;
        }

        public int CookiesPerClick
        {
            get => cookiesPerClick;
            set => cookiesPerClick = value;
        }

        public int CookiesPerSecond
        {
            get => cookiesPerSecond;
            set => cookiesPerSecond = value;
        }
    }
}