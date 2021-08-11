using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Goes on the coin object.
/// </summary>
public class CoinController : MonoBehaviour
{
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private Coin _coin;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _currencySystem.Earn(col.gameObject, _coin.Value);
            gameObject.SetActive(false);
        }
    }
}
