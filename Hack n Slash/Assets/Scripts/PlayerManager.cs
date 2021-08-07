using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : EntityManager
{
    private WeaponManager _weaponManager;
    [SerializeField] private InputListener _inputListener;

    protected override void Awake()
    {
        base.Awake();
        _weaponManager = GetComponentInChildren<WeaponManager>();
    }

    protected override void Start()
    {
        base.Start();

        _inputListener.OnMove += GetComponent<IMovement>().SetMovement;
        _inputListener.OnFire += _weaponManager.Fire;
    }
}
