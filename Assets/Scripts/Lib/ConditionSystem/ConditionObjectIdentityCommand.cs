using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObjectIdentityCommand : ConditionCommand
{
    [HideInInspector]
    [SerializeField]
    ObjectIdentity a_objectIdentity;


    public bool IsDoorOpen(ObjectIdentity a_objectIdentity)
    {
        return a_objectIdentity.IsOpen();
    }

    public bool IsDoorLocked(ObjectIdentity a_objectIdentity)
    {
        return a_objectIdentity.IsLock();
    }


}
