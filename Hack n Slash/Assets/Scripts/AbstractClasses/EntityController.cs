using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField] private EntityData _entity;

    private HealthController _healthManager;

    protected virtual void Awake()
    {
        _healthManager = GetComponent<HealthController>();
    }

    protected virtual void Start()
    {
        GetComponent<IMovementBehavior>().SetMoveSpeed(_entity.Speed);

        if(_healthManager != null)
        {
            _healthManager.SetHealth(_entity.Health);
        }

        if (!(_entity.EntitySprite == null))
        {
            GetComponent<SpriteRenderer>().sprite = _entity.EntitySprite;
        }
    }
}
