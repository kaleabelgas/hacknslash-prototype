using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main system for checking currency.
/// </summary>
[CreateAssetMenu(fileName = "CurrencySystem", menuName = "Systems/Currency")]
public class CurrencySystem : ScriptableObject
{
    public event Action<Dictionary<GameObject, long>> OnEconomyUpdate;
    private readonly Dictionary<GameObject, long> _bankAccounts = new Dictionary<GameObject, long>();

    /// <summary>
    /// Adds <paramref name="amount"/> to balance.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="amount"></param>
    public void AddToBalance(GameObject user, int amount)
    {
        if(!_bankAccounts.ContainsKey(user))
        {
            _bankAccounts.Add(user, amount);
            OnEconomyUpdate?.Invoke(_bankAccounts);
            return;
        }
        OnEconomyUpdate?.Invoke(_bankAccounts);
        _bankAccounts[user] += amount;
    }

    public long GetBalance(GameObject user)
    {
        return _bankAccounts.ContainsKey(user)
            ? _bankAccounts[user]
            : 10;
    }

    public long GetBalanceAllUsers()
    {
        long total = 0;
        foreach (var account in _bankAccounts)
        {
            total += account.Value;
        }
        return total;
    }

    public void RemoveFromBalance(GameObject user, int amount)
    {
        if (!_bankAccounts.ContainsKey(user))
        {
            AddToBalance(user, 0);
        }

        if (amount <= _bankAccounts[user])
        {
            _bankAccounts[user] -= amount;
            OnEconomyUpdate?.Invoke(_bankAccounts);
        }
    }
}
