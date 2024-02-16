using System.Collections.Generic;
using CookieClickerProject.Common;
using UnityEngine;

public class UnitManager : AbstractSingleton<UnitManager>
{
    [Tooltip("現在の工員の数")] int _currentNumberOfWorkers;
    [Tooltip("現在の兵士の数")] int _currentNumberOfSoldiers;
    [Tooltip("現在の兵士の作成上限数")] int _currentMaxNumberOfSoldiers;

    [Space] [Header("兵士の価格：100Gで固定"), SerializeField] [Tooltip("兵士の価格：100Gで固定")]
    int _soldierPrice;

    [Header("キャンプの数"), SerializeField] [Tooltip("キャンプの数")]
    int _numberOfCamps; // 取得する必要アリ

    [Header("工員のプレハブ"), SerializeField] [Tooltip("工員のプレハブ")]
    GameObject _workersPrefab;

    [Header("兵士のプレハブ"), SerializeField] [Tooltip("兵士のプレハブ")]
    GameObject _soldiersPrefab;

    //[Header("工員のリスト"),SerializeField] 
    [Tooltip("工員のリスト")] List<GameObject> _listOfWorkers;

    //[Header("兵士のリスト"),SerializeField] 
    [Tooltip("兵士のリスト")] List<GameObject> _listOfSoldiers;

    [Header("UnitFactory"), SerializeField]
    UnitFactory _unitFactory;


    #region プロパティ

    /// <summary> 現在の工員の数 ※最初は１体</summary>
    public int CurrentNumberOfWorkers
    {
        get => _currentNumberOfWorkers;
        set => _currentNumberOfWorkers = value;
    }

    /// <summary> 現在の兵士の数 </summary>
    public int CurrentNumberOfSoldiers
    {
        get => _currentNumberOfSoldiers;
        set => _currentNumberOfSoldiers = value;
    }

    /// <summary> 現在の兵士の作成上限数：キャンプの数×50</summary>
    public int CurrentMaxNumberOfSoldiers
    {
        get => _currentMaxNumberOfSoldiers;
        set => _currentMaxNumberOfSoldiers = value;
    }

    /// <summary> 兵士の価格 100Gで固定</summary>
    public int SoldierPrice
    {
        get => _soldierPrice;
        //set => _soldierPrice = value;
    }

    #endregion

    void Start()
    {
        CurrentNumberOfWorkers = 1;
        _listOfWorkers = new List<GameObject>();
        _listOfSoldiers = new List<GameObject>();
    }

    void Update()
    {
        CurrentMaxNumberOfSoldiers = _numberOfCamps * 50;
    }

    /// <summary>
    /// 工員を作る
    /// 現在の工員の数を更新
    /// </summary>
    public void CreateWorker()
    {
        _unitFactory.CreateUnit("Worker", CurrentNumberOfWorkers, _workersPrefab, _listOfWorkers);
    }

    /// <summary>
    /// 兵士を作る
    /// 現在の兵士の数を更新
    /// 作成上限数に達していなければ実行できる
    /// </summary>
    public void CreateSoldier()
    {
        // これでOK？　マネージャーは変数以外何も持たせない感じ？
        _unitFactory.CreateUnit("Soldier", CurrentNumberOfSoldiers, _soldiersPrefab, _listOfSoldiers);
    }
}