using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSheetScript : FacilityBase
{
    [SerializeField] GameObject _factory;
    [SerializeField] FacilityType _type;
    [SerializeField] int _waitTime = 5;
    int _counter = 0;

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
    private void OnDestroy()
    {
        ConstructionManager.Instance.BlueSheet = null;
    }
}
