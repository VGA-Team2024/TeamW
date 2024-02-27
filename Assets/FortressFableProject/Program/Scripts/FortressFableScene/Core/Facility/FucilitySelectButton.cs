using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FucilitySelectButton : MonoBehaviour
{
    [SerializeField, Tooltip("購入可能時にやりたいこと")] UnityEvent _isBuyEvent;
    [SerializeField, Tooltip("その商品の値段")] int _price;

    bool ConstructionCheck(string facilityName)
    {
        foreach (FacilityCount si in ConstructionManager.Instance.MaxFaciCount)
        {
            if (si.Name == facilityName)
            {
                return si.MaxCount > si.Count;
            }
        }
        return false;
    }

    public void OnClick(string facilityName)
    {
        if (/*GOLD.Instance.Gold >= _price && お金があるか確認する処理を書く*/ConstructionCheck(facilityName))
        {
            ConstructionManager.Instance.SelectFacilityPriceAndName(_price, facilityName);
            _isBuyEvent.Invoke();
        }
    }
}
