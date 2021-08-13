using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles shop UI and player input on UI
/// </summary>
public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopUIPanel;
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private Item[] itemsInShop;

    private ShopEntity _shopEntity;
    private List<ShopItem> _shopItems;

    private void Awake() => Init();

    /// <summary>
    /// Initializes the shop with what it should sell.
    /// </summary>
    private void Init()
    {
        _shopItems = new List<ShopItem>();

        foreach (Item item in itemsInShop)
        {
            GameObject shopItemObject = Instantiate(shopItemPrefab, shopUIPanel.transform);
            ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();

            shopItem.SetupShopItem(item);
            shopItem.OnPlayerClick += GiveItemToPlayer;

            _shopItems.Add(shopItem);
        }
        shopUIPanel.SetActive(false);
    }

    /// <summary>
    /// Setups the shop depending on the player balance - disables buttons the player can't afford.
    /// Also sets up the UI to work with the specific shop provided in shopEntity.
    /// </summary>
    /// <param name="playerBalance"></param>
    /// <param name="shopEntity"></param>
    public void SetupShop(long playerBalance, ShopEntity shopEntity)
    {
        _shopEntity = shopEntity;

        foreach (var shopItem in _shopItems)
        {
            if (shopItem.Item.Price > playerBalance)
            {
                shopItem.LockItem();
            }
        }
        shopUIPanel.SetActive(true);
    }

    public void CloseShopUI()
    {
        // Do some other stuff like animations
        shopUIPanel.SetActive(false);
    }

    private void GiveItemToPlayer(ShopItem shopItem)
    {
        // Do some other stuff like animations
        _shopEntity.TransferItemToInventory(shopItem.Item, shopItem.Item.Price);
    }
}
