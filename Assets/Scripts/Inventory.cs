using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory
{

    List<Item> m_items = new List<Item>();

    public Inventory() { }


    public Inventory(List<Item> a_items)
    {
        m_items = a_items;
    }


    public void AddItem(Item a_item)
    {
        m_items.Add(a_item);
    }

    public bool RemoveItem(Item a_item)
    {
        return m_items.Remove(a_item);
    }

    public bool RemoveItem(string a_itemName)
    {
         Item item = m_items.Find((o) => o.Name == a_itemName);

        if(item == null)
        {
            return false;
        }

        return m_items.Remove(item);

    }


    public bool HasItem(Item a_item)
    {
        return m_items.Contains(a_item);
    }


    public bool HasItem(string a_itemName)
    {
        return m_items.Find((o) => o.Name == a_itemName) != null;
    }

    public Item GetItem(string a_itemName)
    {
        return m_items.Find((o) => o.Name == a_itemName);
    }


}
