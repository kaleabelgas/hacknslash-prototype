using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LootDrop", menuName = "Loot/LootDrop")]
public class LootDrop : ScriptableObject
{
    public ItemData Item => _item;
    public int Amount => _amount;

    [SerializeField] private ItemData _item;
    [SerializeField] private int _amount;
}
