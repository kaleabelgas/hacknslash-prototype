using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about how much Item to drop.
/// </summary>
[CreateAssetMenu(fileName = "LootDrop", menuName = "Loot/LootDrop")]
public class LootDrop : ScriptableObject
{
    public ItemDrop ItemDrop => _itemDrop;
    public int Amount => _amount;

    [SerializeField] private ItemDrop _item;
    [SerializeField] private int _amount;
    private ItemDrop _itemDrop;
}
