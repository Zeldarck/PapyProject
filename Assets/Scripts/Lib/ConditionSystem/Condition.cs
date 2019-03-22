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
