using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ユニットを作成する機能を持つ
/// ユニット：工員、兵士
/// </summary>
public class UnitFactory : MonoBehaviour
{
    UnitManager _unitManager;

    void Start()
    {
        _unitManager = UnitManager.Instance;
    }

    void Update()
    {
    }

    public IUnit CreateUnit(String type, int numberOfSoldiers, GameObject prefab, List<GameObject> list)
    {
        if (type == "Soldier")
        {
            if (numberOfSoldiers < _unitManager.CurrentMaxNumberOfSoldiers)
            {
                // 作成する
                var go = Instantiate(prefab);
                list.Add(go);
                numberOfSoldiers = list.Count;
                //numberOfSoldiers:割り当てられた値は、どの実行パスでも使用されない
            }
            else
            {
                Debug.LogWarning($"現在、兵士の作成できる上限数を超えています。 " +
                                 $"\n  兵士の数：{numberOfSoldiers}  兵士の作成上限数：{_unitManager.CurrentMaxNumberOfSoldiers}");
            }
        }
        else if (type == "Worker")
        {
            // 作成する
            var go = Instantiate(prefab);
            list.Add(go);
            numberOfSoldiers = list.Count;
            //numberOfSoldiers:割り当てられた値は、どの実行パスでも使用されない
        }

        return null; 
        //return IUnit; // どうやって書くのぉぉぉ;
    }
}