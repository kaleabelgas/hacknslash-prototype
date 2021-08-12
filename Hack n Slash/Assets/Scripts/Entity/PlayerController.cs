using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    private WeaponEntity _weaponController;
    [SerializeField] private InputListener inputListener;

    protected override void Awake()
    {
        base.Awake();
        // TODO: change this to use weaponcontroller on user side instead of weapon itsef.
        _weaponController = GetComponentInChildren<WeaponEntity>();
    }

    protected override void Start()
    {
        base.Start();

        inputListener.OnMove += GetComponent<IMovementBehavior>().SetMovement;
        inputListener.OnFire += _weaponController.Fire;
    }
}
