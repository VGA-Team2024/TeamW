using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GoldMine", menuName = "ScriptableObjects/Facility/GoldMine")]
[System.Serializable]
public class GoldMine : FacilityBase
{
    public int currentGold = 0; // 現在の金量
    public int maxGold = 10000; // 最大金量
}