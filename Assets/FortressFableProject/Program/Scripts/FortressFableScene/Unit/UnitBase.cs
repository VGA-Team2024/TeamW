using UnityEngine;

[System.Serializable]
public abstract class UnitBase : MonoBehaviour, IUnit
{
    [field: SerializeField] public UnitType Type { get; set; } //ユニットの種類
    [field: SerializeField] public int Count { get; set; } //ユニットの数

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