using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ユニットを作成する機能を持つ
/// ユニット：工員、兵士
/// </summary>
public class UnitFactory : MonoBehaviour
{
    [Header("工員のプレハブ"), SerializeField] [Tooltip("工員のプレハブ")]
    GameObject _workersPrefab;

    [Header("兵士のプレハブ"), SerializeField] [Tooltip("兵士のプレハブ")]
    GameObject _soldiersPrefab;


    // ユニットを生成するメソッド 戻り値：UnitBase
    public UnitBase CreateUnit(string type, List<GameObject> list)
    {
        GameObject prefab = null;
        switch (type)
        {
            case "Soldier":
                prefab = _soldiersPrefab;
                break;
            case "Worker":
                prefab = _workersPrefab;
                break;
            default:
                Debug.LogError($"Unknown unit type: {type}");
                return null;
        }

        var go = Instantiate(prefab);
        list.Add(go);

        var unitComponent = go.GetComponent<UnitBase>();
        if (unitComponent != null)
        {
            return unitComponent;
        }
        else
        {
            Debug.LogError($"Prefab does not have an UnitBase component: {type}");
            return null;
        }
    }
}