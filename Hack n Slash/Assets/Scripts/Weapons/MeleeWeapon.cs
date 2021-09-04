using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee")]
public class MeleeWeapon : Weapon
{
    [Tooltip("Radius of the hit area")]
    [SerializeField] private float radius;

    public override void Fire(Vector2 firePoint, Team userTeam)
    {
        Collider2D[] hitInfo = Physics2D.OverlapCircleAll(firePoint, radius);

        foreach (var hits in hitInfo)
        {
            var entityStatsManager = hits.transform.GetComponent<StatsManager>();
            if (entityStatsManager == null) continue;

            var finalDamage = HelperUtils.RandomFromPercent(CriticalChance)
                ? BaseDamage * CriticalDamage
                : BaseDamage;

            entityStatsManager.GetDamaged(userTeam, (int)finalDamage);
        }
    }
}
