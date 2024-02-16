using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GoldMine : MonoBehaviour
{
    private int _currentGold = 0;
    private readonly int _maxGold = 10000;
    [FormerlySerializedAs("GoldPlus")] [SerializeField] private int _goldPlus = 10;
    private float _timer = 0;
    private readonly int _timePlus = 1;
    private Text _goldText = null;

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
    }
}