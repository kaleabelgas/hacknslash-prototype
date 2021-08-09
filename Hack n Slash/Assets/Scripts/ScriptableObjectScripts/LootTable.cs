using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/LootTable")]
public class LootTable : ScriptableObject
{
    public LootDrop[] Drops => _lootDrops;

    [SerializeField] private LootDrop[] _lootDrops;
    
}
