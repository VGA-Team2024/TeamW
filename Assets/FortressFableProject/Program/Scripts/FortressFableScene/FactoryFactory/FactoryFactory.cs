using System;
using UnityEngine;

/// <summary>
/// 施設を生成する処理を持つ
/// </summary>
public class FactoryFactory : MonoBehaviour
{
    [Header("鉱山のプレハブ"), SerializeField] [Tooltip("鉱山のプレハブ")]
    GameObject _minePrefab = default;
    
    [Header("ブルーシートのプレハブ"), SerializeField]
    private GameObject _blueSheetPrefab = default; 
    

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
    
    /// <summary>
    /// 建築中の施設を表すブルーシートを生成するメソッド
    /// </summary>
    /// <param name="type">施設のタイプ</param>
    /// <param name="waitTime">建築完了までの時間</param>
    /// <returns>生成されたブルーシートのGameObject</returns>
    public GameObject CreateBlueSheet(FacilityBase.FacilityType type, float waitTime)
    {
        GameObject blueSheetObject = Instantiate(_blueSheetPrefab);
        BlueSheetScript blueSheetScript = blueSheetObject.AddComponent<BlueSheetScript>();
        // ブルーシートスクリプトに建築に関する詳細を設定
        blueSheetScript.SetConstructionDetails(type, waitTime, CreateFacility(type));

        return blueSheetObject;
    }
}