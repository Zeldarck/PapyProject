using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionKeyValueCommand : ConditionCommand
{
    [HideInInspector]
    [SerializeField]
    bool wesh;

    [HideInInspector]
    [SerializeField]
    Condition wesh2;

    public bool test2(bool wesh, Condition wesh2)
    {
        return true;
    }
}
