using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private Entity entity;

    private void Start()
    {
        GetComponent<IMovement>().SetMoveSpeed(entity.Speed);

        if(!(entity.EntitySprite is null))
        {
            GetComponent<SpriteRenderer>().sprite = entity.EntitySprite;
        }
    }
}
