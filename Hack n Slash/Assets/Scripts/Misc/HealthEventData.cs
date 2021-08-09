using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEventArgs
{
    private int _damage;
    private GameObject _entity;

    public int Damage { 
        get => _damage;
        set => _damage = value;
    }
    public GameObject Entity
    {
        get => _entity;
        set => _entity = value;
    }
}
