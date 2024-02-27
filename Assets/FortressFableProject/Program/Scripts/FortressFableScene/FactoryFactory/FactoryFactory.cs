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
    public GameObject CreateFactory(FacilityBase.FacilityType type)
    {
        GameObject prefab = null;
        switch (type)
        {
            // 鉱山
            case FacilityBase.FacilityType.Mine:
                prefab = _minePrefab;
                break;
            default:
                Debug.LogError($"Unknown factory type: {type}");
                return null;
        }

        var go = Instantiate(prefab);

        return go;
    }
}