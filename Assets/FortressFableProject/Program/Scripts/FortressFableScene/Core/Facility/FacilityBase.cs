using UnityEngine;


[System.Serializable]
public class FacilityBase : ScriptableObject
{
    public UnitBase.FacilityType type; // 施設の種類
    public bool boo; // 施設が建設されているかどうか
    public Vector3 position; //施設の位置
    public float timePerProduction; //Tの生産時間
    public int assetPerProduction; //Tの生産量
}