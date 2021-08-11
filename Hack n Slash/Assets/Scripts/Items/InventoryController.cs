using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private readonly Dictionary<Item, int> _inventory = new Dictionary<Item, int>();

    public void Receive(Item item, int quantity)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory.Add(item, quantity);
        }
        else
        {
            _inventory[item] += quantity;
        }
    }
}
