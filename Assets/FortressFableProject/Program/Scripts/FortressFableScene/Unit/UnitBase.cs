using UnityEngine;

[System.Serializable]
public abstract class UnitBase : ScriptableObject, IUnit
{
    public int count;
    public enum FacilityType
    {
        Base,
        Mine,
        TrainingFacility,
        Camp
    }

    public abstract void Move();
    public abstract void Action();
}