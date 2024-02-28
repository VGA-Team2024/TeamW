using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldMine : FacilityBase
{

   public int CurrentGold = 0;
    int _timePlus = 1;
    Text _goldText = null;
    int _currentGold = 0;
   public  int _maxGold = 10000;
    [SerializeField]  int _goldPlus = 10;
    float _timer = 0;

    private void Start()
    {
        _goldText = GetComponent<Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _timePlus && _currentGold > _maxGold)
        {
            _currentGold += _goldPlus;
            _timer = 0;
        }
        else
        {
            _timer = 0;
        }
    }

    private void OnMouseDown()
    {

        Debug.Log("回収");
        // Goldの合計変数に＋＝する
        _currentGold = 0;
    }
}