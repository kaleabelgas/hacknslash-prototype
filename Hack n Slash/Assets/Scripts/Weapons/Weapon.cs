using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] private int baseDamage;

    [Tooltip("Float from 0 to 1")]
    [SerializeField] private float criticalChance;

    [Tooltip("Float from 1.5 to 2.5")]
    [Range(1.5f, 2.5f)]
    [SerializeField] private float criticalDamage;

    public int BaseDamage => baseDamage;
    public float CriticalChance => criticalChance;
    public float CriticalDamage => criticalDamage;

    public abstract void Fire(Vector2 firePoint, GameObject user);
}
