using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on the item you want to drop.
/// </summary>
public class ItemDrop : MonoBehaviour
{
    public Item Item => _item;
    [SerializeField] private Item _item;
}
