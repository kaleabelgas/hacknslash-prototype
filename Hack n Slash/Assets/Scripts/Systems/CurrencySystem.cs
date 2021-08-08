using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : ScriptableObject
{
    public event Action<Dictionary<GameObject, long>> OnEconomyUpdate;
    private readonly Dictionary<GameObject, long> _economy = new Dictionary<GameObject, long>();

    public void Earn(GameObject user, int amount)
    {
        if(!_economy.ContainsKey(user))
        {
            _economy.Add(user, amount);
            OnEconomyUpdate?.Invoke(_economy);
            return;
        }
        OnEconomyUpdate?.Invoke(_economy);
        _economy[user] += amount;
    }

    public long CheckBalance(GameObject user)
    {
        return _economy.ContainsKey(user)
            ? _economy[user]
            : 0;
    }

    public bool Withdraw(GameObject user, int amount)
    {
        if(amount <= _economy[user])
        {
            _economy[user] -= amount;
            return true;
        }
        return false;
    }
}
