using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionKeyValueCommand : ConditionCommand
{
    [HideInInspector]
    [SerializeField]
    bool example;


    public bool Example(bool example)
    {
        return example;
    }
}
