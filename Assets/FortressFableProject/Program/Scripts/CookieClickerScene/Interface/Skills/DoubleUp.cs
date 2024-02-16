using UnityEngine;

public class DoubleUp : MonoBehaviour, IUpGrade
{
    public int Level { get ; set; }

    public void Execute()
    {
        DoubleUpClick();
    }

    void DoubleUpClick()
    {

    }
}
