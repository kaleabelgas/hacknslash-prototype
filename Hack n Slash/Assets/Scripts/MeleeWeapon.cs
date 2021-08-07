using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee")]
public class MeleeWeapon : Weapon
{
    public override void Fire()
    {
        Debug.Log("Firing");
    }
}
