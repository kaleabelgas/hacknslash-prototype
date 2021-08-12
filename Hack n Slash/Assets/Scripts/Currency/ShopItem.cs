using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int price;

    public Item Item => item;
    public int Price => price;

    public event Action<ShopItem> OnPlayerClick;

    private void Awake()
    {
        // Tells ButtonClick method to run whenever the button onClick event is invoked.
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        OnPlayerClick?.Invoke(this);
    }
}
