using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<ItemSO.Type, Dictionary<string, ItemSO>> inventory = new();

    public void Add(ItemSO item)
    {
        if (!inventory.TryGetValue(item.type, out var dict))
            inventory.Add(item.type, new Dictionary<string, ItemSO>());
        inventory[item.type].Add(item.name, item);
    }

    public void Remove(ItemSO item)
    {
        if (!inventory.TryGetValue(item.type, out var dict))
        {
            Debug.LogWarning($"Did not find any item in the inventory with this type: {item.type}");
            return;
        }

        if (!inventory[item.type].Remove(item.name))
        {
            Debug.LogWarning($"Removing {item.name} has failed. No such key found.");
        }
    }

    public bool Contains(ItemSO item)
    {
        if (!inventory.TryGetValue(item.type, out var dict))
        {
            return false;
        }

        if (!inventory[item.type].TryGetValue(item.name, out var value))
        {
            return false;
        }

        return true;
    }
    
    public ItemSO Get(string itemName, ItemSO.Type itemType)
    {
        if (inventory.TryGetValue(itemType, out var dict))
        {
            if (dict.TryGetValue(itemName, out var value))
                return value;
        }

        return null;
    }

    public bool TryGet(string itemName, ItemSO.Type itemType, out ItemSO item)
    {
        if (inventory.TryGetValue(itemType, out var dict) && dict.TryGetValue(itemName, out item))
            return true;
        item = null;
        return false;
    }
}
