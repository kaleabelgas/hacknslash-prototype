using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on the item you want to drop.
/// </summary>
public class ItemController : MonoBehaviour, ICollideable
{
    [SerializeField] private Item item;

    public void InitializeItem(Item item)
    {
        this.item = item;
        GetComponent<SpriteRenderer>().sprite = item.Sprite;
    }
    public void Interact(GameObject interactor)
    {
        item.Use(interactor);
    }
}
