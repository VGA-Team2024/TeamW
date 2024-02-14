using UnityEngine;
using UniRx;

namespace CookieClickerProject.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int totalCookies;
        [SerializeField] private int cookiesPerClick;
        [SerializeField] private int cookiesPerSecond;


        // リアクティブプロパティ
        private ReactiveProperty<int> TotalCookiesReactiveProperty { get; set; }
        private ReactiveProperty<int> CookiesPerClickReactiveProperty { get; set; }
        private ReactiveProperty<int> CookiesPerSecondReactiveProperty { get; set; }

        public PlayerData()
        {
            // リアクティブプロパティの初期化
            TotalCookiesReactiveProperty = new ReactiveProperty<int>(totalCookies);
            CookiesPerClickReactiveProperty = new ReactiveProperty<int>(cookiesPerClick);
            CookiesPerSecondReactiveProperty = new ReactiveProperty<int>(cookiesPerSecond);
        }

        public int TotalCookies
        {
            get => TotalCookiesReactiveProperty.Value;
            set => TotalCookiesReactiveProperty.Value = value;
        }

        public int CookiesPerClick
        {
            get => CookiesPerClickReactiveProperty.Value;
            set => CookiesPerClickReactiveProperty.Value = value;
        }

        public int CookiesPerSecond
        {
            get => CookiesPerSecondReactiveProperty.Value;
            set => CookiesPerSecondReactiveProperty.Value = value;
        }
    }
}