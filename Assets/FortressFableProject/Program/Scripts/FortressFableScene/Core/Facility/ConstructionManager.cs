using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ConstructionManager : AbstractSingleton<ConstructionManager>
{
    [SerializeField, Tooltip("ポジションセット用プレハブ")] GameObject[] _factoryPosSetPrefab;
    [SerializeField, Tooltip("いくつ作れるかクラスのリスト")] List<FacilityCount> _maxFaciCount;
    public List<FacilityCount> MaxFaciCount { get { return _maxFaciCount; } set { _maxFaciCount = value; } }

    [SerializeField] EventSystem _es;
    ConstructPos _constructPos;
    GameObject _blueSheet = null;
    public GameObject BlueSheet { get { return _blueSheet; } set { _blueSheet = value; } }
    GameObject _factoryPosSet;
    [SerializeField, Tooltip("建設できるときのボタンの処理")] UnityEvent _isSetButton;
    int _selectFacilityPrice;
    string _selectFacilityName;

    /// <summary>作る建物が選ばれたときに呼ばれる </summary>
    /// <param name="name">作るプレハブの名前</param>
    public void SelectFacility(string name)
    {
        foreach (GameObject g in _factoryPosSetPrefab)
        {
            if (name == g.name)
            {
                _factoryPosSet = Instantiate(g);
            }
        }
        //_factoryPosSet = Instantiate(_factoryPosSetPrefab);
        _constructPos = _factoryPosSet.GetComponent<ConstructPos>();
        _constructPos.Es = _es;
    }
    /// <summary>選ばれている建物の情報をポジション決定まで持っておく</summary>
    /// <param name="prise">建物の価格</param>
    /// <param name="name">建物の名前</param>
    public void SelectFacilityPriceAndName(int prise, string name)
    {
        _selectFacilityPrice = prise;
        _selectFacilityName = name;
    }
    /// <summary> ポジション決定時に呼ばれる</summary>
    public void FacilitySet()
    {
        if (_constructPos.IsSet && _blueSheet == null)
        {
            _isSetButton.Invoke();
            //GOLD.Instance.Gold -= _selectFacilityPrice;
            //お金減らす処理
            foreach (FacilityCount si in _maxFaciCount)
            {
                if (si.Name == _selectFacilityName)
                {
                    si.Count++;
                }//立っている建物の数をふやす。最大立てられる数
            }
            _constructPos.Set();
        }
    }
    /// <summary>ポジション決定をキャンセルしたときに呼ばれる</summary>
    public void FacilitySetCancel()
    {
        Destroy(_factoryPosSet);
    }

}

public class FacilityCount
{
    public string Name;
    public int MaxCount;
    public int Count;
}