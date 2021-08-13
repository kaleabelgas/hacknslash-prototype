using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// One-time buy Shop Item. 
/// </summary>
public class ShopItem : MonoBehaviour
{
    private Item _item;
    public Item Item => _item;

    public event Action<ShopItem> OnPlayerClick;

    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemImage;

    private void Awake()
    {
        // Tells ButtonClick method to run whenever the button onClick event is invoked.
        GetComponent<Button>().onClick.AddListener(
            () =>
            {
                OnPlayerClick?.Invoke(this);
                LockItem();
            });
    }

    public void SetupShopItem(Item item)
    {        
        _item = item;

        itemImage.sprite = item.ItemSprite;
        price.text = item.Price.ToString();
        itemName.text = item.name.ToString();
    }
    public void LockItem()
    {
        // do other stuff when item is not clickable
        GetComponent<Button>().interactable = false;
        itemName.color = Color.red;
    }
}
