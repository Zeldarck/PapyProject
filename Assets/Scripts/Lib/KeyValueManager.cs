using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyValueManager
{

    Dictionary<string, bool> m_bools = new Dictionary<string, bool>();
    Dictionary<string, int> m_ints = new Dictionary<string, int>();
    Dictionary<string, float> m_floats = new Dictionary<string, float>();
    Dictionary<string, string> m_strings = new Dictionary<string, string>();



    public bool GetValueBool(string a_key)
    {
        bool res = false;

        m_bools.TryGetValue(a_key, out res);
            
        return res;
    }

    public int GetValueInt(string a_key)
    {
        int res = 0;

        m_ints.TryGetValue(a_key, out res);

        return res;
    }

    public float GetValueFloat(string a_key)
    {
        float res = 0;

        m_floats.TryGetValue(a_key, out res);

        return res;
    }

    public string GetValueString(string a_key)
    {
        string res = "";

        m_strings.TryGetValue(a_key, out res);

        return res;
    }


    public void SetValueBool(string a_key, bool a_value)
    {
        m_bools[a_key] = a_value;
    }

    public void SetValueInt(string a_key, int a_value)
    {
        m_ints[a_key] = a_value;
    }

    public void SetValueFloat(string a_key, float a_value)
    {
        m_floats[a_key] = a_value;
    }

    public void SetValueString(string a_key, string a_value)
    {
        m_strings[a_key] = a_value;
    }



}
