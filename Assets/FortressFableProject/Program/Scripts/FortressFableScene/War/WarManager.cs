using System.Collections.Generic;
using System.Linq;
using CookieClickerProject.Common;
using UnityEngine;

/// <summary>
/// 戦争の機能を持つ
/// ウェーブ：NEXT
/// </summary>
public class WarManager : AbstractSingleton<WarManager>, IWar
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

    [Header("IResourceを継承したもののリスト"), SerializeField] [Tooltip("IResourceを継承したもののリスト")]
    List<Component> _iResource;

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
        _iResource = new List<Component>();
    }

    void Update()
    {
    }

    public void StartWave()
    {
        _isWin = false;
        // ここでenemyForceとmyForceを取得
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
            // ReduceFacilityGold();  // 施設の貯蓄したゴールドを０にする
        }

        if (_gold < 0)
        {
            _gold = 0;
        }
    }

// 必要なこと
// ・施設側で「IResource」を継承していること
// ・貯蓄されたゴールドの数が代入された変数がアクセスできること

    /// <summary>
    /// 「IResource」を継承した、施設（鉱山）の貯蓄したゴールドを０にする
    /// </summary>
     // void ReduceFacilityGold()
     // {
     //     _iResource.Clear();
     //     _iResource = GetComponents(typeof(IResource)).ToList();
     //
     //     foreach (IResource item in _iResource)
     //     {
     //         // 変数にアクセスして、値を０にする
     //         item.Gold = 0;
     //     }
     // }
}

// // あくまでもイメージした仮置きのインターフェース
// public interface IResource
// {
//     public int Gold { get; set; }
// }