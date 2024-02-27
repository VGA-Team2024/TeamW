using UnityEngine;

public abstract class FactoryBase : MonoBehaviour, IConstruction
{
    public virtual void Build()
    {
    }

    public abstract void Effect();
}