using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoldMine : MonoBehaviour
{
   public int CurrentGold = 0;
    int MaxGold = 10000;
    [SerializeField] int GoldPlus = 10;
    float _timer = 0;
    int _timePlus = 1;
    Text _GoldText = null;

    private void Start()
    {
        _GoldText = GetComponent<Text>();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _timePlus && CurrentGold > MaxGold)
        {
            CurrentGold += GoldPlus;
            _timer = 0;
            
        }
        else
        {
            _timer = 0;
        }
        
    }
    private void OnMouseDown()
    {
        Debug.Log("‰ñû");
        // Gold‚Ì‡Œv•Ï”‚É{‚·‚éG
        CurrentGold = 0;
    }
   
}
