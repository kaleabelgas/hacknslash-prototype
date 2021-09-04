using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This monobehaviour handles dropping of loot from entity.
/// </summary>
public class LootDropController : MonoBehaviour
{
    [SerializeField] private LootTable lootTable;

    public void DropLoot()
    {
        if (lootTable == null) return;
        if (lootTable.ItemBundle == null) return;

        foreach (LootBundle bundle in lootTable.ItemBundle)
        {
            for (int amount = 0; amount < bundle.Amount; amount++)
            {
                // replace with object pooler
                GameObject item = new GameObject(bundle.Item.ItemName);
                var itemController = item.AddComponent<ItemController>();
                itemController.InitializeItem(bundle.Item);
            }
        }
    }
}