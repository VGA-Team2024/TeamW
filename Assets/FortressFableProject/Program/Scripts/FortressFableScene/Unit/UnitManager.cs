using System.Collections.Generic;
using System.Linq;
using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
using UnityEngine;

/// <summary>
/// ユニットを生成する機能を呼び出すクラス
/// ユニット：工員、兵士
/// </summary>
public class UnitManager : AbstractSingleton<UnitManager>
{
    GameManager _gameManager = default;

    [Tooltip("現在の工員の数")] int _currentNumberOfWorkers;
    [Tooltip("現在の兵士の数")] int _currentNumberOfSoldiers;
    [Tooltip("現在の兵士の作成上限数")] int _currentMaxNumberOfSoldiers;

    [Space] [Header("兵士の価格：100Gで固定"), SerializeField] [Tooltip("兵士の価格：100Gで固定")]
    int _soldierPrice;

    [Header("キャンプの数"), SerializeField] [Tooltip("キャンプの数")]
    int _numberOfCamps; // 取得する必要アリ


    [Header("工員のリスト"), SerializeField] [Tooltip("工員のリスト")]
    List<GameObject> _listOfWorkers;

    [Header("兵士のリスト"), SerializeField] [Tooltip("兵士のリスト")]
    List<GameObject> _listOfSoldiers;

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
        _gameManager = GameManager.Instance;
        _listOfWorkers = new List<GameObject>();
        _listOfSoldiers = new List<GameObject>();
        CreateWorker(); // 初めに一体生成
    }

    void Update()
    {
    }

    /// <summary>
    /// 工員を作る
    /// 現在の工員の数を更新
    /// </summary>
    public void CreateWorker()
    {
        var worker = _unitFactory.CreateUnit("Worker", _listOfWorkers);
        // 追加の工員管理ロジックが必要
        CurrentNumberOfWorkers = _listOfWorkers.Count;
        // ゲームマネージャーに保存する
        _gameManager.AddUnit(worker);
    }

    /// <summary>
    /// 兵士を作る
    /// 現在の兵士の数を更新
    /// 作成上限数に達していなければ実行できる
    /// </summary>
    public void CreateSoldier()
    {
        // 所持ゴールドがコストを下回っていたら、兵士の生成不可
        if (SaveAndLoad.Instance.StorageData.PlayerData.TotalMoney < _soldierPrice)
        {
            Debug.Log("Cannot create more soldiers. Need more gold.");
            return;
        }

        // キャンプの数に応じて、作成上限を更新
        _numberOfCamps =
            SaveAndLoad.Instance.StorageData.GameData.Facilities.Count(count =>
                count.Type == FacilityBase.FacilityType.Camp);
        _currentMaxNumberOfSoldiers = _numberOfCamps * 50;

        if (_currentNumberOfSoldiers < _currentMaxNumberOfSoldiers)
        {
            var soldier = _unitFactory.CreateUnit("Soldier", _listOfSoldiers);
            // 追加の兵士管理ロジックが必要
            CurrentNumberOfSoldiers = _listOfSoldiers.Count;
            // ゲームマネージャーに保存する
            _gameManager.AddUnit(soldier);
            DecreaseGold(_soldierPrice);
        }
        else
        {
            Debug.LogWarning("Cannot create more soldiers. Max capacity reached.");
        }
    }

    /// <summary>
    /// 兵士生成時の支払い機能
    /// </summary>
    /// <param name="cost"></param>
    void DecreaseGold(int cost)
    {
        _gameManager.AddMoney(-cost);
    }
}