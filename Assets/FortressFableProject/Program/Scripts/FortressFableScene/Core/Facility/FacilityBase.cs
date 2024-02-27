using UnityEngine;


[System.Serializable]
public class FacilityBase : MonoBehaviour
{
    public FacilityType Type { get; set; } // 施設の種類
    public bool IsProducing { get; set; } //生産中かどうか
    public Vector3 Position { get; set; } //施設の位置
    public float WaitTime { get; set; } // 施設作成の経過時間
    public float TimePerProduction { get; set; } //Tの生産時間
    public int AssetPerProduction { get; set; } //Tの生産量

    public enum FacilityType
    {
        Base,
        Mine,
        TrainingFacility,
        Camp
    }
}