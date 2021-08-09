using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string Name => _name;

    [SerializeField] private string _name;
}
