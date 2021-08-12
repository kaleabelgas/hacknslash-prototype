using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntity : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CurrencySystem currencySystem;
    
    private bool _playerNearby;
    private bool _shopIsOpen;
    private GameObject _player;

    private void Awake()
    {
        inputListener.OnInteract += OpenShopMenu;
    }

    private void OpenShopMenu()
    {
        if (!_playerNearby) return;
        if (_shopIsOpen) return;
        _shopIsOpen = true;

        // Interact with Shop UI. Create Shop UI script.
        // Pass in currencySystem[user] to shop ui to change text color etc.
    }

    public void BuyItem(Item item)
    {
        _player.GetComponent<InventoryController>().AddToInventory(item);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerNearby = collision.CompareTag("Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerNearby = collision.CompareTag("Player");
    }
}
