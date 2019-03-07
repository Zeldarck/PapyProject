using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField]
    Sprite m_sprite;
    [SerializeField]
    string m_name;
    [SerializeField]


    public string Name { get => m_name; }
}
