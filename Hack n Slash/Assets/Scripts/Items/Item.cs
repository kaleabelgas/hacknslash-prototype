using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string Name => _name;

    [SerializeField] private string _name;
    public abstract void Use(GameObject usedBy);
}
