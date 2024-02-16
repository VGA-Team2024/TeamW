using UnityEngine;

public abstract class UnitBase : MonoBehaviour, IUnit
{
    public abstract void Move();
    public abstract void Action();
}