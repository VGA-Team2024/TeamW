﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSheetScript : FacilityBase
{
    [SerializeField, Tooltip("建設される建物のプレハブ")] GameObject _factory;
    [SerializeField, Tooltip("建設されるもののタイプ")] FacilityType _type;
    [SerializeField, Tooltip("建設完了するまでの時間")] float _waitTime = 5;
    [SerializeField, Tooltip("建設開始からの時間 見る用")] float _counter = 0;

    public void ConstructWait(int Progress)
    {
        base.Type = _type;
        base.IsProducing = false;
        base.Position = this.gameObject.transform.position;
        _counter = Progress;
        Tweener tw = DOTween.To(() => _counter, x => _counter = x, _waitTime, _waitTime - _counter).SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                base.WaitTime = _waitTime - _counter;
            }).OnComplete(() =>
            {
                Instantiate(_factory).transform.position = this.transform.position;
                Destroy(ConstructionManager.Instance.BlueSheet);
            });
    }
    
    public void SetConstructionDetails(FacilityType type, float waitTime, GameObject factory)
    {
        _type = type;
        _waitTime = (int)waitTime;
        _factory = factory;
    }
    
    private void OnDestroy()
    {
        ConstructionManager.Instance.BlueSheet = null;
    }
}