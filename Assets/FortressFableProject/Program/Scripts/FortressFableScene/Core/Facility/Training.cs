using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Soldiers", menuName = "ScriptableObjects/Facility/Soldiers")]
[System.Serializable]
public class Training : FacilityBase
{
    public int producingSoldiers; // 養成所で生産中の兵士 
    int _Dexresesgold = 100;

    private void OnMouseDown()
    {
        Debug.Log("生産");
        /*
         * += _Dexresesgold;
         * -= _IncreaseSoldiers;
         */
    }
}