using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{
    [SerializeField] private LootTable lootTable;

    public void DropItem()
    {
        foreach(LootDrop drop in lootTable.Drops)
        {
            for (int i = 0; i < drop.Amount; i++)
            {
                Debug.Log(drop.Item.ToString());
            }
        }
    }
}