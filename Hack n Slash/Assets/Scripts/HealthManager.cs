using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthManager : MonoBehaviour
{
    private int _healthDefault;

    private int _currentHealth;

    public static event Action<string> OnEntityDeath;

    public static event Action<int> OnEntityHit;

    public int CurrentHealth => _currentHealth;

    public virtual void GetDamaged(int damage, GameObject hitter)
    {
        OnEntityHit?.Invoke(damage);
        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die() => OnEntityDeath?.Invoke(gameObject.tag);

    public void GetHealed(int heal) => _currentHealth = Mathf.Min(_healthDefault, _currentHealth + heal);

    public void SetHealth(int health = 0)
    {
        _healthDefault = health;
        _currentHealth = _healthDefault;
    }
}
