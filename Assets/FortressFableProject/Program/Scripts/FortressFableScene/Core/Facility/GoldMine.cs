using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldMine : FacilityBase
{
    Text _goldText = null;
    public int _maxGold = 10000;
    [SerializeField] int _goldPlus = 10;
    float _timer = 0;

    private void Start()
    {
        _goldText = GetComponent<Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < TimePerProduction && AssetPerProduction > _maxGold)
        {
            AssetPerProduction += _goldPlus;
            _timer = 0;
            if (_goldText != null)
            {
                _goldText.text = $"Gold: {AssetPerProduction}";
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("回収");
        // Goldの合計変数に＋＝する
        AssetPerProduction = 0;
        if (_goldText != null)
        {
            _goldText.text = $"Gold: {AssetPerProduction}";
        }
    }
}