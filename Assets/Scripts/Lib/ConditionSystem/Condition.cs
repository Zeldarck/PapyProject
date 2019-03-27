using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;


[Serializable]
public class Condition
{
    [SerializeField]
    bool m_isList;

    [SerializeField]
    bool m_isOr;

    [SerializeField]
    List<Condition> m_conditions;

    [SerializeField]
    ConditionCommand m_conditionCommand;

    public bool Execute()
    {
        if (m_isList)
        {
            if (m_isOr)
            {
                return OrExecute();
            }
            else
            {
                return AndExecute();
            }
        }
        else
        {
            if (m_conditionCommand != null)
            {
                return m_conditionCommand.Execute();
            }
        }

        return true;
    }

    private bool AndExecute()
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

    private bool OrExecute()
    {
        bool res = false;
        foreach (Condition condition in m_conditions)
        {
            res = condition.Execute();
            if (res)
            {
                break;
            }
        }

        return res;
    }


}


