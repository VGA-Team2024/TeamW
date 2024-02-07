using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    int Level { get; set; }
    void Execute();
}
