using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FucilitySelectButton : MonoBehaviour
{
    [SerializeField, Tooltip("�w���\���ɂ�肽������")] UnityEvent _isBuyEvent;
    [SerializeField, Tooltip("���̏��i�̒l�i")] int _price;

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
        if (/*GOLD.Instance.Gold >= _price && ���������邩�m�F���鏈��������*/ConstructionCheck(facilityName))
        {
            ConstructionManager.Instance.SelectFacilityPriceAndName(_price, facilityName);
            _isBuyEvent.Invoke();
        }
    }
}
