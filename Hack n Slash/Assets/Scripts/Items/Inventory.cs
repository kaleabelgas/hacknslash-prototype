using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ItemBundle> startItems;

    [NonSerialized] private Dictionary<Item, int> _inventory;

    public void Init()
    {
        _inventory = new Dictionary<Item, int>(startItems.Count);
        foreach (var itemBundle in startItems)
        {
            if (_inventory.ContainsKey(itemBundle.Item))
            {
                Debug.LogWarning($"Can't add {itemBundle.Item.ItemName} twice!");
                continue;
            }

            _inventory.Add(itemBundle.Item, itemBundle.Amount);
        }
    }

    public bool UseItem(Item item, GameObject usedBy)
    {
        if (!_inventory.ContainsKey(item) || _inventory[item] <= 0)
            return false;

        item.Use(usedBy);
        _inventory[item]--;
        return true;
    }

    public void AddItem(Item item)
    {
        if (_inventory.ContainsKey(item))
            _inventory[item]++;
        else
            _inventory.Add(item, 1);
    }
}
