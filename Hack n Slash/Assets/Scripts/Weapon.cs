﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private int _damage;

    public Sprite WeaponSprite => _weaponSprite;

    public int Damage => _damage;

    public abstract void Fire();
}
