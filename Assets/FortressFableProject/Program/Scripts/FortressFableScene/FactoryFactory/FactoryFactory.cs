using System;
using UnityEngine;

/// <summary>
/// 施設を生成する処理を持つ
/// </summary>
public class FactoryFactory : MonoBehaviour
{
    [Header("鉱山のプレハブ"), SerializeField] [Tooltip("鉱山のプレハブ")]
    GameObject _minePrefab = default;

    /// <summary>
    /// ユニットを生成するメソッド 戻り値：IConstruction
    /// </summary>
    /// <param name="type"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public GameObject CreateFacility(FacilityBase.FacilityType type)
    {
        GameObject prefab = type switch
        {
            FacilityBase.FacilityType.Mine => _minePrefab,
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported facility type: {type}")
        };

        return Instantiate(prefab);
    }
}