using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 工員のクラス
///
/// 建設予定地に向かって移動するだけ
/// 建設中でなければ、移動しない
/// 
/// 最初に1人かならずいる。
/// 施設の建設時に建設予定地に移動し、建物を建設する。
/// マップを適当に徘徊してもよい。
/// </summary>
[CreateAssetMenu(fileName = "Worker", menuName = "ScriptableObjects/Unit/Worker")]
[System.Serializable]
public class Worker : UnitBase
{
    [Header("移動速度"), SerializeField] float _speed = default;

    NavMeshAgent _navMeshAgent = default;

    [Tooltip("建設予定地")] Vector3 _targetPosition = default;

    [Header("生成直後にいさせたい場所"), SerializeField]
    GameObject _startPosition = default;

    void Start()
    {
        if (_startPosition) transform.position = _startPosition.transform.position;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }

    void Update()
    {
        if (ConstructionManager.Instance.BlueSheet)
        {
            // 建設予定地を見つける
            _targetPosition = ConstructionManager.Instance.BlueSheet.transform.position;
            Move();
        }
    }

    /// <summary>
    /// 建設予定地に向かって移動する
    /// </summary>
    public override void Move()
    {
        _navMeshAgent.SetDestination(_targetPosition);
    }

    public override void Action()
    {
        throw new System.NotImplementedException();
    }
}