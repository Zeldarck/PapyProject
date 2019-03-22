using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;



[Serializable]
public class ConditionSet
{
    [SerializeField]
    List<ConditionCollection> m_conditions;


    public bool Execute()
    {
        bool res = false;
        foreach (ConditionCollection conditionCollec in m_conditions)
        {
            res = conditionCollec.Execute();
            if (res)
            {
                break;
            }
        }

        return res;
    }
}


[Serializable]
public class ConditionCollection
{
    [SerializeField]
    List<Condition> m_conditions;


    public bool Execute()
    {
        bool res = true;
        foreach (Condition condition in m_conditions)
        {
            res = condition.Execute();
            if (!res)
            {
                break;
            }
        }

        return res;
    }
}


[Serializable]
public class Condition
{
    [SerializeField]
    ConditionCommand m_conditionCommand;

    public bool Execute()
    {
        if(m_conditionCommand != null)
        {
            return m_conditionCommand.Execute();
        }

        return true;
    }

}


