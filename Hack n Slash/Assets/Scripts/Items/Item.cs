using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string Name => itemName;
    public Sprite ItemSprite => itemSprite;

    public int Price => price;

    [SerializeField] private string itemName;
    // Maybe add a locked itemsprite
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private int price;
    public abstract void Use(GameObject usedBy);
}
