using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee")]
public class MeleeWeapon : Weapon
{
    [SerializeField] private float radius;

    public override void Fire(Vector2 firePoint, GameObject user)
    {
        Collider2D[] hitInfo = Physics2D.OverlapCircleAll(firePoint, radius);

        foreach(var hits in hitInfo)
        {
            var statsManager = hits.transform.GetComponent<StatsManager>();
            if (statsManager == null)
            {
                continue;
            }
            statsManager.GetDamaged(user, Damage);
        }
    }
}
