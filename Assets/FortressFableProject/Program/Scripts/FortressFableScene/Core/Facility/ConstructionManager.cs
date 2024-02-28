using CookieClickerProject.Common;
using CookieClickerProject.Data;
using FortressFableProject.Program.Scripts.Common.Core;
using System;
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

    [SerializeField] TypePrefab[] _facilityPrefabs;
    [SerializeField] TypePrefab[] _blueSheetPrefabs;
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
            GameManager.Instance.AddMoney(-_selectFacilityPrice);
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

    public void GameLoad(FacilityData data)
    {
        // FactoryManagerを介して施設のGameObjectを生成
        GameObject prefab = FactoryManager.Instance.FactoryBuilding(data.Type);
        if (prefab == null) return; // 施設の生成に失敗した場合は処理を中断

        prefab.transform.position = data.Position; // 位置を設定

        // 建築後の施設の設定
        if (data.IsProducing)
        {
            FacilityBase fb = prefab.GetComponent<FacilityBase>();
            if (fb == null) return;
            fb.Type = data.Type;
            fb.IsProducing = true;
            // タイプに応じた追加のプロパティ設定
            if (data.Type != FacilityBase.FacilityType.Mine) return;
            fb.TimePerProduction = data.TimePerProduction;
            fb.AssetPerProduction = data.AssetPerProduction;
        }
        else // 建築中の施設の設定（ブルーシートを使用）
        {
            BlueSheetScript bss = prefab.GetComponent<BlueSheetScript>();
            if (bss == null) return;
            bss.Type = data.Type;
            bss.IsProducing = false;
            bss.ConstructWait((int)data.WaitTime);
        }
    }

}
[Serializable]
public class FacilityCount
{
    public string Name;
    public int MaxCount;
    public int Count;
}
[Serializable]
public class TypePrefab
{
    public FacilityBase.FacilityType Type;
    public GameObject Prefab;
}