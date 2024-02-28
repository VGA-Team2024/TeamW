using UnityEngine;

[System.Serializable]
public abstract class UnitBase : MonoBehaviour, IUnit
{
    [field: SerializeField] public UnitType Type { get; set; } //���j�b�g�̎��
    [field: SerializeField] public int Count { get; set; } //���j�b�g�̐�

    public enum UnitType
    {
        Base,
        Worker,
        Soldier,
        Tank
    }

    public abstract void Move();
    public abstract void Action();
}