using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthController : MonoBehaviour
{
    [SerializeField] private HealthSystemEventChannel eventChannel;

    public event Action<HealthEventArgs> OnEntityDeath;
    public event Action<HealthEventArgs> OnEntityHit;

    private int _healthDefault;

    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    public virtual void GetDamaged(int damage, GameObject hitter)
    {
        if (hitter.CompareTag(gameObject.tag))
        {
            return;
        }

        Debug.Log("Hurt", this);

        OnEntityHit?.Invoke(new HealthEventArgs
        {
            Damage = damage,
            Entity = gameObject
        });

        eventChannel.InvokeEntityHit(gameObject, damage);

        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        eventChannel.InvokeEntityDeath(gameObject);
        OnEntityDeath?.Invoke(new HealthEventArgs
        {
            Entity = gameObject
        });
    }

    public void GetHealed(int heal) => _currentHealth = Mathf.Min(_healthDefault, _currentHealth + heal);

    public void SetHealth(int health = 0)
    {
        _healthDefault = health;
        _currentHealth = _healthDefault;
    }
}
