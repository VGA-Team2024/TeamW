using UnityEngine;

[System.Serializable]
public abstract class UnitBase : MonoBehaviour, IUnit
{
    public UnitType Type { get; set; } //ユニットの種類
    public int Count { get; set; } //ユニットの数

    public enum UnitType
    {
        Worker,
        Soldier,
        Tank
    }

    public abstract void Move();
    public abstract void Action();
}