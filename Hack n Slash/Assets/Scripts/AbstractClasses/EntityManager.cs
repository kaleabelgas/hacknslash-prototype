using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityManager : MonoBehaviour
{
    [SerializeField] private Entity _entity;

    private HealthManager _healthManager;

    protected virtual void Awake()
    {
        _healthManager = GetComponent<HealthManager>();
    }

    protected virtual void Start()
    {
        GetComponent<IMovement>().SetMoveSpeed(_entity.Speed);

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
