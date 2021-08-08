using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private int _damage;

    public Sprite WeaponSprite => _weaponSprite;

    public int Damage => _damage;

    public abstract void Fire(Vector2 firePoint, GameObject user);
}
