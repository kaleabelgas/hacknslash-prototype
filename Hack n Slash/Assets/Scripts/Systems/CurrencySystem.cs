using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : ScriptableObject
{
    public event Action<Dictionary<GameObject, long>> OnEconomyUpdate;
    private readonly Dictionary<GameObject, long> _bankAccount = new Dictionary<GameObject, long>();

    public void Earn(GameObject user, int amount)
    {
        if(!_bankAccount.ContainsKey(user))
        {
            _bankAccount.Add(user, amount);
            OnEconomyUpdate?.Invoke(_bankAccount);
            return;
        }
        OnEconomyUpdate?.Invoke(_bankAccount);
        _bankAccount[user] += amount;
    }

    public long CheckBalance(GameObject user)
    {
        return _bankAccount.ContainsKey(user)
            ? _bankAccount[user]
            : 0;
    }

    public long CheckBalanceAllUsers()
    {
        long total = 0;
        foreach (var account in _bankAccount)
        {
            total += account.Value;
        }
        return total;
    }

    public bool Withdraw(GameObject user, int amount)
    {
        if(amount <= _bankAccount[user])
        {
            _bankAccount[user] -= amount;
            OnEconomyUpdate?.Invoke(_bankAccount);
            return true;
        }
        return false;
    }
}
