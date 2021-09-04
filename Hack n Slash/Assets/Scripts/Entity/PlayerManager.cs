using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private LootDropController _lootDropper;
    private StatsManager _statsManager;
    private PlayerAnimationController _animationController;
    private WeaponEntityController _weaponController;
    [SerializeField] private InputListener inputListener;


    private void Awake()
    {
        _statsManager = GetComponent<StatsManager>();
        _lootDropper = GetComponent<LootDropController>();
        _animationController = GetComponent<PlayerAnimationController>();
        _weaponController = GetComponentInChildren<WeaponEntityController>();
    }
    private void Start()
    {
        _statsManager.OnDeath += _lootDropper.DropLoot;
        _statsManager.OnHit += _animationController.PlayHitAnimation; 
        inputListener.OnMove += GetComponent<IMovementBehavior>().SetMovement;
        inputListener.OnFire += _weaponController.Fire;
    }
}
