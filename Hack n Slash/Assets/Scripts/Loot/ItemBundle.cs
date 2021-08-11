using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about how much Item to drop.
/// </summary>
[CreateAssetMenu(fileName = "LootDrop", menuName = "Loot/LootDrop")]
public class ItemBundle : ScriptableObject
{
    public ItemEntity ItemEntity => itemEntity;
    public int Amount => amount;

    [SerializeField] private ItemEntity itemEntity;
    [SerializeField] private int amount;
}
