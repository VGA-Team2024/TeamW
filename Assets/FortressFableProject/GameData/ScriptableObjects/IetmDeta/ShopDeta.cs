using CookieClickerProject.Common;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ShopDeta.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]

    public class ShopDeta : ScriptableObject
    {
        public List<ItemDeta> ItemDeta = new List<ItemDeta>();
    }

    [System.Serializable]
    public class ItemDeta
    {
        [SerializeField] private string ietmName;
        [SerializeField] private int ietmAssets;
        [SerializeField] private int ietmID;

        private ReactiveProperty<string> IetmNameReactiveProperty { get; set; }
        private ReactiveProperty<int> IetmAssetsReactiveProperty { get; set; }
        private ReactiveProperty<int> IetmIDReactiveProperty { get; set; }

        public ItemDeta()
        {
            // リアクティブプロパティの初期化
            IetmNameReactiveProperty = new ReactiveProperty<string>(ietmName);
            IetmAssetsReactiveProperty = new ReactiveProperty<int>(ietmAssets);
            IetmIDReactiveProperty = new ReactiveProperty<int>(ietmID);
        }
        public string IetmName
        {
            get => IetmNameReactiveProperty.Value;
            set => IetmNameReactiveProperty.Value = value;
        }

        public int IetmAssets
        {
            get => IetmAssetsReactiveProperty.Value;
            set => IetmAssetsReactiveProperty.Value = value;
        }

        public int IetmID
        {
            get => IetmIDReactiveProperty.Value;
            set => IetmIDReactiveProperty.Value = value;
        }


    }

}





