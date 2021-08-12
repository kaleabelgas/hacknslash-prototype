using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopUIPanel;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Item[] itemsInShop;
    [SerializeField] private ShopEntity shopEntity;

    private List<GameObject> _shopItemButtons;

    private void Awake() => Init();

    /// <summary>
    /// Initializes the shop with what it should sell.
    /// </summary>
    private void Init()
    {
        _shopItemButtons = new List<GameObject>();

        foreach (Item item in itemsInShop)
        {
            GameObject shopItemButton = Instantiate(buttonPrefab, shopUIPanel.transform);

            ShopItem shopItem = shopItemButton.GetComponent<ShopItem>();

            shopItemButton.name = shopItem.Item.name;
            shopItem.OnPlayerClick += BuyItem;

            _shopItemButtons.Add(shopItemButton);
        }
    }

    public void SetupShop(long balance)
    {
        shopUIPanel.SetActive(true);

        foreach(GameObject shopItemButton in _shopItemButtons)
        {
            var price = shopItemButton.GetComponent<ShopItem>().Price;

            if (price > balance)
            {
                // TODO: Change text, colors etc for expensive item
                shopItemButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                // TODO: Change text, colors etc for affordable item
            }
        }
    }

    public void CloseShopUI()
    {
        // Do some other stuff like animations
        shopUIPanel.SetActive(false);
    }

    private void BuyItem(ShopItem shopItem)
    {
        // Do some other stuff like animations
        shopEntity.TransferItemToInventory(shopItem.Item, shopItem.Price);
    }
}
