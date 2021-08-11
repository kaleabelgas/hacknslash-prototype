using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee")]
public class MeleeWeapon : Weapon
{
    [SerializeField] private float radius;
    public event Action<Collider2D[]> HitEntity;

    public override void Fire(Vector2 firePoint, GameObject user)
    {
        Collider2D[] hitInfo = Physics2D.OverlapCircleAll(firePoint, radius);

        foreach(var hits in hitInfo)
        {
            Debug.Log("Hit " + hits.name);
            var healthManager = hits.transform.GetComponent<HealthController>();
            if (healthManager == null)
            {
                continue;
            }
            healthManager.GetDamaged(Damage, user);
        }

        HitEntity?.Invoke(hitInfo);
    }
}
