using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSystem : MonoBehaviour
{
    [SerializeField] private HealthSystemEventChannel _eventChannel;
    [SerializeField] private List<EntityLootTable> entityLootTables;

    private void Start()
    {
        _eventChannel.OnEntityDeath += DropItem;
    }

    public void DropItem(GameObject entity)
    {
        EntityLootTable lootTable = entityLootTables.Find(x => entity.CompareTag(x.EntityTag));

        foreach(ItemDrop drops in lootTable.ItemDrops)
        {
            for (int i = 0; i < drops.Amount; i++)
            {
                Debug.Log(drops.ItemType.ToString());
            }
        }
    }
}
[Serializable]
public  class EntityLootTable
{
    public string EntityTag;
    public List<ItemDrop> ItemDrops;
}
[Serializable]
public class ItemDrop
{
    public ItemType ItemType;
    public int Amount;
}