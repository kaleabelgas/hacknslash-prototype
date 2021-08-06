using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Scriptable Object/Entity")]
public class MeleeWeapon : ScriptableObject
{
    [SerializeField]
    private Sprite weaponSprite;
    [SerializeField]
    private int damage;

    public Sprite WeaponSprite => weaponSprite;

    public int Damage => damage;
}
