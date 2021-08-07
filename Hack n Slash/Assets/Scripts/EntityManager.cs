using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityManager : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private InputListener _inputListener;

    private void Start()
    {
        GetComponent<IMovement>().SetMoveSpeed(_entity.Speed);
        _inputListener.OnMove += GetComponent<IMovement>().SetMovement;

        if (!(_entity.EntitySprite == null))
        {
            GetComponent<SpriteRenderer>().sprite = _entity.EntitySprite;
        }
    }
}
