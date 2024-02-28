using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : FacilityBase
{
    int _IncreaseSoldiers = 1;
    int _Dexresesgold = 100;

    float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < 10f)
        {
            UnitManager.Instance.CreateSoldier();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("生産");
        /*
         * += _Dexresesgold;
         * -= _IncreaseSoldiers;
         */
    }
}