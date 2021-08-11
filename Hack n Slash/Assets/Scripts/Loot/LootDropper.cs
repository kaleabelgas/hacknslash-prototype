using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This monobehaviour handles dropping of loot from entity.
/// </summary>
public class LootDropper : MonoBehaviour
{
    [SerializeField] private LootTable lootTable;

    public void DropLoot()
    {
        foreach(LootDrop drop in lootTable.Drops)
        {
            for (int i = 0; i < drop.Amount; i++)
            {
                Debug.Log(drop.ItemDrop.ToString());
            }
        }
    }
}