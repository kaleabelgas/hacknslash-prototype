using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on the item you want to drop.
/// </summary>
public class ItemEntity : MonoBehaviour
{
    public Item Item => item;
    [SerializeField] private Item item;

    // Create drop animation or something
    public void Drop()
    {

    }
}
