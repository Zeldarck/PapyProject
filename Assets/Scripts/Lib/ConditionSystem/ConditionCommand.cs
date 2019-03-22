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

    [HideInInspector]
    [SerializeField]
    string method;


    public string Method { get => method; set => method = value; }

    public bool Execute()
    {
        MethodInfo info  = GetType().GetMethod(method);

        if (info != null)
        {


            object[] param = new object[info.GetParameters().Length];

            for (int e = 0; e < info.GetParameters().Length; e++)
            {
                ParameterInfo parametter = info.GetParameters()[e];
                for (int i = 0; i < GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Length; ++i)
                {
                    if (GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[i].Name == parametter.Name)
                    {
                        param[e] = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[i].GetValue(this);
                    }
                }
            }

            return (bool)info.Invoke(this, param);
        }

        return true;
    }
}
