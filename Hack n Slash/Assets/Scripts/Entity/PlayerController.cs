using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    private WeaponController _weaponController;
    [SerializeField] private InputListener _inputListener;

    protected override void Awake()
    {
        base.Awake();
        _weaponController = GetComponentInChildren<WeaponController>();
    }

    protected override void Start()
    {
        base.Start();

        _inputListener.OnMove += GetComponent<IMovementBehavior>().SetMovement;
        _inputListener.OnFire += _weaponController.Fire;
    }
}
