using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int healthDefault;

    public static event Action<string> OnEntityDeath;

    public static event Action<int> OnEntityHit;

    public int CurrentHealth { get; private set; }

    public virtual void GetDamaged(int damage, GameObject hitter)
    {
        OnEntityHit?.Invoke(damage);
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die() => OnEntityDeath?.Invoke(gameObject.tag);

    public void GetHealed(int heal) => CurrentHealth = Mathf.Min(healthDefault, CurrentHealth + heal);

    public void SetHealth(int health = 0)
    {
        healthDefault = health;
        CurrentHealth = healthDefault;
    }
}
