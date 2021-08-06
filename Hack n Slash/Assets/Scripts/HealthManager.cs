using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int CurrentHealth { get; private set; }

    public event Action<string> OnEntityDeath;
    public event Action<int> OnEntityHit;
    
    private int healthDefault;

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

    public void GetHealed(int _heal) => CurrentHealth = Mathf.Min(healthDefault, CurrentHealth + _heal);

    public void SetHealth(int _health = 0)
    {
        healthDefault = _health;
        CurrentHealth = healthDefault;
    }
}
