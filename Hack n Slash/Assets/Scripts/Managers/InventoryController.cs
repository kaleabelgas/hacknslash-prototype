using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private CurrencySystem _currencySystem;

    private readonly Dictionary<ItemType, int> _inventory = new Dictionary<ItemType, int>();

    public void Receive(ItemType item, int quantity)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory.Add(item, quantity);
            return;
        }
        _inventory[item] += quantity;
    }

    public void Drop(ItemType item, int quantity)
    {
        if (!_inventory.ContainsKey(item))
        {
            return;
        }
        _inventory[item] -= quantity;
    }

    public void PickupCurrency(CurrencyData currency, int quantity)
    {
        _currencySystem.Earn(gameObject, currency.Value * quantity);
    }

    public void SpendCurrency(int amount, Action action)
    {
        _currencySystem.Withdraw(gameObject, amount, out bool canSpend);
        if (canSpend)
        {
            action.Invoke();
        }
    }
}
