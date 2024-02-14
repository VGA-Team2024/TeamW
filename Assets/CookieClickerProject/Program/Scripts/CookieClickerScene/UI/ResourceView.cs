using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace CookieClickerProject.CookieClickerScene.UI
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private Text totalCookiesText;
        [SerializeField] private Button cookieButton; // クッキーボタンを追加

        public event Action OnCookieButtonClick; // イベントを追加

        private void Start()
        {
            cookieButton.onClick.AddListener(() => OnCookieButtonClick?.Invoke());
        }

        public void UpdateTotalCookies(decimal totalCookies)
        {
            totalCookiesText.text = $"Total Cookies: {totalCookies}";
        }
    }
}