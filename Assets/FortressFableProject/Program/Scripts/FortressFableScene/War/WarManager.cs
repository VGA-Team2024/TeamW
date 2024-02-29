using System.Collections;
using System.Linq;
using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
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

    [Header("ウェーブが進むごとに増やす敵の数"), SerializeField] [Tooltip("ウェーブが進むごとに増やす敵の数")]
    int _addEnemyForce = 20;

    [Header("勝ったか"), SerializeField] [Tooltip("勝ったか")]
    bool _isWin;

    [Header("敵の戦力"), SerializeField] [Tooltip("敵の戦力")]
    int _enemyForce;

    [Header("味方の戦力"), SerializeField] [Tooltip("味方の戦力")]
    int _myForce;

    [Header("現在のゴールド"), SerializeField] [Tooltip("現在のゴールド")]
    int _gold;

    [Header("戦争の結果が出るまでの時間"), SerializeField] [Tooltip("戦争の結果が出るまでの時間")]
    float _timeOfWar = 10f;

    WaitForSeconds _wfs = default;


    #region プロパティ

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
        foreach (var count in SaveAndLoad.Instance.StorageData.GameData.Units.Where(count =>
                     count.Type == UnitBase.UnitType.Soldier))
        {
            _myForce = count.Count;
        }

        _wfs = new WaitForSeconds(_timeOfWar);
        _enemyForce = 100;
    }

    void Update()
    {
        // テスト用
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWave();
        }

        // 10秒後にEndWaveを呼び出す
        StartCoroutine(CallEndWave());
    }

    public void StartWave()
    {
        _gold = SaveAndLoad.Instance.StorageData.PlayerData.TotalMoney;
        // ここでmyForceを取得
        _isWin = false;
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
            // ウェーブ加算
            GameManager.Instance.AddWave();
            ChangeEnemyForce();
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
            var decrease = -(_enemyForce - _myForce) * 10;
            GameManager.Instance.AddMoney(decrease);
            //_myForce = 0;
        }

        // マイナスにならないように調整
        if (_gold < 0)
        {
            GameManager.Instance.AddMoney(-_gold);
        }
    }

    /// <summary>
    /// 勝ったらウェーブ加算後に敵の戦力を増やす
    /// </summary>
    void ChangeEnemyForce()
    {
        _enemyForce += _addEnemyForce;
    }

    /// <summary>
    /// 数秒後にEndWaveを呼ぶ
    /// </summary>
    /// <returns></returns>
    IEnumerator CallEndWave()
    {
        yield return _wfs;
        EndWave();
    }
}