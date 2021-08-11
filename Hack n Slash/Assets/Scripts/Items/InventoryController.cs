using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        inventory.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        var pickup = other.GetComponent<ItemEntity>();
        inventory.AddItem(pickup.Item);
    }
}
