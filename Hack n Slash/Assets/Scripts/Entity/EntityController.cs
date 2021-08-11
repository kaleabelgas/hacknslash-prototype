using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    private LootDropper _lootDropper;
    private EntityAnimationController _animationController;

    private HealthController _healthController;

    protected virtual void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _lootDropper = GetComponent<LootDropper>();
        _animationController = GetComponent<EntityAnimationController>();
    }

    protected virtual void Start()
    {
        GetComponent<IMovementBehavior>().SetMoveSpeed(_entity.Speed);

        if(_healthController != null)
        {
            _healthController.SetHealth(_entity.Health);
            _lootDropper.DropLoot();

        }
        
        if(_animationController != null)
        {
            _healthController.OnEntityHit += _animationController.PlayHitAnimation;
        }

        if (_entity.EntitySprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = _entity.EntitySprite;
        }
    }
}
