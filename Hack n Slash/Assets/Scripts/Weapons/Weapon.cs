using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] private int damage;
    public int Damage => damage;

    public abstract void Fire(Vector2 firePoint, GameObject user);
}
