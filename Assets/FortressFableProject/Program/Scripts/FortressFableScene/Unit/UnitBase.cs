using UnityEngine;

[System.Serializable]
public abstract class UnitBase : MonoBehaviour, IUnit
{
    public UnitType Type { get; set; } //���j�b�g�̎��
    public int Count { get; set; } //���j�b�g�̐�

    public enum UnitType
    {
        Worker,
        Soldier,
        Tank
    }

    public abstract void Move();
    public abstract void Action();
}