using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/LootTable")]
public class LootTable : ScriptableObject
{
    public LootBundle[] ItemBundle => itemBundle;

    [SerializeField] private LootBundle[] itemBundle;
    
}
