using System;
using CookieClickerProject.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CookieClickerProject.CookieClickerScene.UI
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI totalCookiesText;
        [SerializeField] private InputUIButton cookieButton;

        public event Action OnCookieButtonClick; // イベントを追加

        private void Start()
        {
            cookieButton.OnClick.AddListener(Click);
        }

        private void Click(InputUIButton inputUIButton)
        {
            OnCookieButtonClick?.Invoke();
        }

        public void UpdateTotalCookies(decimal totalCookies)
        {
            totalCookiesText.text = $"Total Cookies: {totalCookies}";
            Debug.Log("Total Cookies: " + totalCookies);
        }
    }
}