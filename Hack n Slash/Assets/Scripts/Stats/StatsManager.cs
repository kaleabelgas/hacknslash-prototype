using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private HealthSystemEventChannel eventChannel;

    public event Action OnEntityDeath;
    public event Action<int> OnEntityHit;


    private Dictionary<StatType, int> _currentStats = new Dictionary<StatType, int>
    {
        {StatType.MaxHealth, 100},
        {StatType.Health, 100},
        {StatType.Speed, 20},
        {StatType.Armor, 0}
    };

    private IMovementBehavior movementBehavior;

    private void Awake()
    {
        movementBehavior = GetComponent<IMovementBehavior>();
        Init(entity);
    }

    public void AddToStat(StatType stat, int amount)
    {
        switch (stat)
        {
            case StatType.MaxHealth:
                _currentStats[StatType.MaxHealth] += amount;
                _currentStats[StatType.Health] += amount;
                return;
            case StatType.Health:
                _currentStats[StatType.Health] += Mathf.Clamp(amount, 0, _currentStats[StatType.MaxHealth]);
                return;
            case StatType.Armor:
                _currentStats[StatType.Armor] = Mathf.Clamp(amount, 0, 70);
                return;
            case StatType.Speed:
                movementBehavior.SetMoveSpeed(_currentStats[StatType.Speed] += amount);
                return;
            default:
                return;
        }
    }

    public int GetStat(StatType stat)
    {
        return _currentStats[stat];
    }

    public void Init(Entity entity)
    {
        _currentStats[StatType.MaxHealth] = entity.Health;
        _currentStats[StatType.Health] = entity.Health;
        _currentStats[StatType.Speed] = entity.Speed;
        _currentStats[StatType.Armor] = entity.Armor;

        movementBehavior.SetMoveSpeed(_currentStats[StatType.Speed]);
    }

    #region Health System
    public virtual void GetDamaged(GameObject hitter, int damage)
    {
        if (hitter.CompareTag(gameObject.tag))
        {
            return;
        }

        int totalDamage = (int)(damage * (float)(_currentStats[StatType.Armor] / 100));

        _currentStats[StatType.Health] = Mathf.Max(0, _currentStats[StatType.Health] - totalDamage);


        eventChannel.InvokeEntityHit(gameObject, damage);
        OnEntityHit?.Invoke(damage);

        if (_currentStats[StatType.Health] <= 0)
        {
            Die();
        }

    }
    public virtual void Die()
    {
        eventChannel.InvokeEntityDeath(gameObject);
        OnEntityDeath?.Invoke();
    }

    #endregion

}
