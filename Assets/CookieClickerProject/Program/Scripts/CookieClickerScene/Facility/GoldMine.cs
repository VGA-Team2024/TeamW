using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldMine : MonoBehaviour
{

   public int CurrentGold = 0;
    int MaxGold = 10000;
    [SerializeField] int GoldPlus = 10;
    int _timePlus = 1;
    Text _GoldText = null;
    int _currentGold = 0;
    int _maxGold = 10000;
    [SerializeField]  int _goldPlus = 10;
    float _timer = 0;
    Text _goldText = null;

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

        Debug.Log("âÒé˚");
        // GoldÇÃçáåvïœêîÇ…Å{ÅÅÇ∑ÇÈ
        _currentGold = 0;
    }
}