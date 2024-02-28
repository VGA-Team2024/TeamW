using System.Linq;
using CookieClickerProject.Common;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 戦争の機能を持つ
/// ウェーブ：NEXT
/// </summary>
public class WarManager : MonoBehaviour, IWar
{
    [Header("現在のウェーブ"), SerializeField] [Tooltip("現在のウェーブ")]
    int _currentWave;

    [Header("勝ったか"), SerializeField] [Tooltip("勝ったか")]
    bool _isWin;

    [Header("敵の戦力"), SerializeField] [Tooltip("敵の戦力")]
    int _enemyForce;

    [Header("味方の戦力"), SerializeField] [Tooltip("味方の戦力")]
    int _myForce;

    [Header("現在のゴールド"), SerializeField] [Tooltip("現在のゴールド")]
    int _gold;


    #region プロパティ

    /// <summary> 現在のウェーブ </summary>
    public int CurrentWave
    {
        get => _currentWave;
        //set => _currentWave = value;
    }

    /// <summary> 勝ったか </summary>
    public bool IsWin
    {
        get => _isWin;
        //set => _isWin = value;
    }

    #endregion

    void Start()
    {
        _currentWave = SaveAndLoad.Instance.StorageData.GameData.Wave;
        _gold = SaveAndLoad.Instance.StorageData.PlayerData.TotalMoney;
        foreach (var count in SaveAndLoad.Instance.StorageData.GameData.Units.
                     Where(count => count.Type == UnitBase.UnitType.Soldier))
        {
            _myForce = count.Count;
        }
    }

    void Update()
    {
        // テスト用
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWave();
        }

        // 10秒後にEndWaveを呼び出す
        
        
        
        
    }

    public void StartWave()
    {
        _isWin = false;
        // ここでenemyForceとmyForceを取得
        _enemyForce = 100;
    }

    public void EndWave()
    {
        ReduceSoldiersAndGold(Comparison());
    }

    /// <summary>
    /// NEXTに表示されている兵力 vs 自分が持っている兵士の数(兵力)
    /// 自分の兵力が高ければ 戦争に勝利 
    /// </summary>
    /// <returns> 勝ったら真、負けたら偽 </returns>
    bool Comparison()
    {
        if (_myForce >= _enemyForce)
        {
            // 次のウェーブ
            _currentWave++;
            return _isWin = true;
        }
        else
        {
            Debug.LogWarning("We lost.");
            return _isWin = false;
        }
    }

    /// <summary>
    /// 兵士の数を減らす
    /// 負けた時はゴールドも減らす
    /// </summary>
    void ReduceSoldiersAndGold(bool isWin)
    {
        if (isWin)
        {
            // 切り捨て
            _myForce -= _enemyForce / 2;
        }
        else
        {
            // 負けたら
            _myForce = 0;
            _gold -= (_enemyForce - _myForce) * 10;
        }

        if (_gold < 0)
        {
            _gold = 0;
        }
    }
}