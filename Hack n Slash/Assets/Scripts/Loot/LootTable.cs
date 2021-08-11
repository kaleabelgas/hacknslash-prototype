using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/LootTable")]
public class LootTable : ScriptableObject
{
    public ItemBundle[] ItemBundle => itemBundle;

    [SerializeField] private ItemBundle[] itemBundle;
    
}
