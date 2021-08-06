using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Scriptable Object/Entity")]
public class MeleeWeapon : ScriptableObject
{
    public Sprite WeaponSprite;
    public int Damage;
}
