using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    private LootDropController _lootDropper;
    private StatsManager _statsManager;
    private PlayerAnimationController _animationController;
    private WeaponController _weaponController;
    [SerializeField] private Player player;
    [SerializeField] private InputListener inputListener;


    private void Awake()
    {
        _statsManager = GetComponent<StatsManager>();
        _lootDropper = GetComponent<LootDropController>();
        _animationController = GetComponent<PlayerAnimationController>();
        _weaponController = GetComponent<WeaponController>();
    }
    private void Start()
    {
        if (!hasAuthority) return;
        _statsManager.InitializeStats(player);
        _statsManager.OnDeath += _lootDropper.DropLoot;
        _statsManager.OnHit += _animationController.PlayHitAnimation; 
        inputListener.OnMove += GetComponent<IMovementBehavior>().SetMovementDirection;
        inputListener.OnFire += () => _weaponController.Fire(player.Team);
    }
}
