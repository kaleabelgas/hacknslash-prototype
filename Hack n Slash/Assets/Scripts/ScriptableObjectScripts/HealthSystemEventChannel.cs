using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthSystemEventChannel", menuName = "Systems/HealthSystemEventChannel")]
public class HealthSystemEventChannel : ScriptableObject
{
    public event Action<HealthEventArgs> OnEntityDeath;
    public event Action<HealthEventArgs> OnEntityHit;

    public void InvokeEntityDeath(GameObject entity)
    {
        OnEntityDeath?.Invoke(new HealthEventArgs
        {
            Entity = entity
        });

    }
    public void InvokeEntityHit(GameObject entity, int amount)
    {
        OnEntityHit?.Invoke(new HealthEventArgs
        {
            Entity = entity,
            Damage = amount
        });
    }
}
