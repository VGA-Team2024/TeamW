using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 兵士のクラス
/// 
/// 生成直後に位置する場所・向かう先を設定すれば動く
/// 
/// 兵士育成所からキャンプに歩いていき、重ならない配置でいい感じに待機する。
/// マップを適当に徘徊してもよい。
/// 価格：１００G　作成上限数：キャンプの数*50
/// </summary>
[CreateAssetMenu(fileName = "Soldier", menuName = "ScriptableObjects/Unit/Soldier")]
[System.Serializable]
public class Soldier : UnitBase
{
    [Header("出てくる場所：兵士育成所"), SerializeField]
    GameObject _start = default;

    [Header("待機する目的地：キャンプ"), SerializeField]
    GameObject _target = default;

    NavMeshAgent _navMeshAgent = default;

    void Start()
    {
        // 生成直後の配置場所
        transform.position = _start.transform.position;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Move();
    }


    public override void Move()
    {
        _navMeshAgent.SetDestination(_target.transform.position);
    }

    public override void Action()
    {
        throw new System.NotImplementedException();
    }
}