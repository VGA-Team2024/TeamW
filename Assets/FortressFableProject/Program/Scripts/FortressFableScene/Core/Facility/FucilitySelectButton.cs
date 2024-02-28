using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static FacilityBase;

public class FucilitySelectButton : MonoBehaviour
{
    [SerializeField, Tooltip("購入可能時にやりたいこと")] UnityEvent _isBuyEvent;
    [SerializeField, Tooltip("その商品の値段")] int _price;
    [SerializeField, Tooltip("建設される建物のタイプ")] FacilityBase.FacilityType _facilityType;

    bool ConstructionCheck(FacilityBase.FacilityType type)
    {
        foreach (FacilityCount si in ConstructionManager.Instance.MaxFaciCount)
        {
            if (si.Type == type)
            {
                return si.MaxCount > si.Count;
            }
        }
        return false;
    }//建設上限に達していないか

    public void OnClick()
    {
        if (SaveAndLoad.Instance.StorageData.PlayerData.TotalMoney >= _price && ConstructionCheck(_facilityType))
        {
            ConstructionManager.Instance.SelectFacilityPriceAndName(_price, _facilityType);
            ConstructionManager.Instance.SelectFacility(_facilityType);
            _isBuyEvent.Invoke();
        }
    }
}
