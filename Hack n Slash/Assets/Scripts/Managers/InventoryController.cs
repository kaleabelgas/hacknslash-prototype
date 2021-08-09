using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private CurrencySystem _currencySystem;

    private readonly Dictionary<ItemData, int> _inventory = new Dictionary<ItemData, int>();

    public void Receive(ItemData item, int quantity)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory.Add(item, quantity);
            return;
        }
        _inventory[item] += quantity;
    }

    public void Drop(ItemData item, int quantity)
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
