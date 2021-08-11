using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    private LootDropController _lootDropper;
    private StatsManager _statsManager;
    private EntityAnimationController _animationController;

    protected virtual void Awake()
    {
        _statsManager = GetComponent<StatsManager>();
        _lootDropper = GetComponent<LootDropController>();
        _animationController = GetComponent<EntityAnimationController>();
    }
    protected virtual void Start()
    {
        _statsManager.OnEntityDeath += _lootDropper.DropLoot;
        _statsManager.OnEntityHit += _animationController.PlayHitAnimation;
    }
}
