using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthSystemEventChannel", menuName = "Misc/HealthSystemEventChannel")]
public class HealthSystemEventChannel : ScriptableObject
{
    public event Action<GameObject> OnEntityDeath;
    public event Action<GameObject, int> OnEntityHit;

    public void InvokeEntityDeath(GameObject entity)
    {
        OnEntityDeath?.Invoke(entity);
    }
    public void InvokeEntityHit(GameObject entity, int amount)
    {
        OnEntityHit?.Invoke(entity, amount);
    }
}
