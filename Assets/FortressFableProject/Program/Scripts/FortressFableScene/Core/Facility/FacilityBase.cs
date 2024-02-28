using UnityEngine;


[System.Serializable]
public class FacilityBase : MonoBehaviour
{
    [field: SerializeField] public FacilityType Type { get; set; } // 施設の種類
    [field: SerializeField] public bool IsProducing { get; set; } //生産中かどうか
    [field: SerializeField] public Vector3 Position { get; set; } //施設の位置
    [field: SerializeField] public float WaitTime { get; set; } // 施設作成の経過時間
    [field: SerializeField] public float TimePerProduction { get; set; } //Tの生産時間
    [field: SerializeField] public int AssetPerProduction { get; set; } //Tの生産量

    public enum FacilityType
    {
        Base,
        Mine,
        TrainingFacility,
        Camp
    }
}