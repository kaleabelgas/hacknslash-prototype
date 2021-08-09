using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField] private EntityData _entity;
    private ItemDropController _itemDropController;
    private EntityAnimationController _animationController;

    private HealthController _healthController;

    protected virtual void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _itemDropController = GetComponent<ItemDropController>();
        _animationController = GetComponent<EntityAnimationController>();
    }

    protected virtual void Start()
    {
        GetComponent<IMovementBehavior>().SetMoveSpeed(_entity.Speed);

        if(_healthController != null)
        {
            _healthController.SetHealth(_entity.Health);

            if (_itemDropController != null)
            {
                _healthController.OnEntityDeath += (args) => {
                    _itemDropController.DropItem();
                };
            }
        }
        
        if(_animationController != null)
        {
            _healthController.OnEntityHit += (args) =>
            {
                _animationController.PlayHitAnimation();
            };
        }

        if (_entity.EntitySprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = _entity.EntitySprite;
        }
    }
}
