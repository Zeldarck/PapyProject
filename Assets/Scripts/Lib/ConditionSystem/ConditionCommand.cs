using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

[Serializable]
public class ConditionCommand : ScriptableObject
{

    [SerializeField]
    string test;

    [SerializeField]
    string method;

    public string Method { get => method; set => method = value; }
}
