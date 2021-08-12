using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Goes on the coin object.
/// </summary>
public class CoinEntity : MonoBehaviour
{
    [SerializeField] private CurrencySystem currencySystem;
    [SerializeField] private Coin coin;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            currencySystem.AddToBalance(col.gameObject, coin.Value);
            gameObject.SetActive(false);
        }
    }
}
