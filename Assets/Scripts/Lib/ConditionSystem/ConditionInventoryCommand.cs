using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConditionInventoryCommand : ConditionCommand
{

    [SerializeField]
    string pilou;

    [HideInInspector]
    [SerializeField]
    bool toto;

    [HideInInspector]
    [SerializeField]
    string rt;

    public bool test(bool toto, string rt)
    {
        return toto;
    }
    public bool test2()
    {
        return true;
    }
    public bool test3()
    {
        return true;
    }
}
