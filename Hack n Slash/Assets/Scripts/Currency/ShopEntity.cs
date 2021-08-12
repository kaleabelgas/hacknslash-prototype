using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntity : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private CurrencySystem currencySystem;
    [SerializeField] private ShopUI shopUI;
    
    private bool _playerNearby;
    private bool _shopIsOpen;
    private GameObject _player;

    private void Awake()
    {
        inputListener.OnInteract += OpenShopMenu;
        inputListener.OnEscape += CloseShopMenu;
    }

    private void OpenShopMenu()
    {
        if (!_playerNearby) return;
        if (_shopIsOpen) return;
        
        _shopIsOpen = true;


        // Pass in currencySystem.CheckBalance(_player) to shop ui to change text color etc.

        shopUI.SetupShop(currencySystem.GetBalance(_player));
    }
    
    // Possibly just hook up shopUI.CloseShopUI directly to the esc event of InputListener.
    private void CloseShopMenu()
    {
        shopUI.CloseShopUI();
    }

    /// <summary>
    /// Adds item to player inventory and subtracts the price from player balance.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="price"></param>
    public void TransferItemToInventory(Item item, int price)
    {
        currencySystem.RemoveFromBalance(_player, price);
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
