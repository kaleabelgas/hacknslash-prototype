using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string ItemName => itemName;
    public Sprite Sprite => sprite;

    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    public abstract void Use(GameObject usedBy);
}
