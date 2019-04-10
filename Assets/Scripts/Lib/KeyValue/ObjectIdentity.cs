using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ObjectIdentity", menuName = "Object Identity", order = 52)]
public class ObjectIdentity : ScriptableObject
{
    public void Lock(bool a_value)
    {
        KeyValueManager.Instance.KeyValueData.SetValueBool(name + "Lock", a_value);
    }

    public bool IsLock()
    {
        return KeyValueManager.Instance.KeyValueData.GetValueBool(name + "Lock");
    }

    public void Open(bool a_value)
    {
        KeyValueManager.Instance.KeyValueData.SetValueBool(name + "IsOpen", a_value);
    }

    public bool IsOpen()
    {
        return KeyValueManager.Instance.KeyValueData.GetValueBool(name + "IsOpen");
    }

}
