using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityData : ScriptableObject
{
    [SerializeField] private Sprite _entitySprite;
    [SerializeField] private int _speed;
    [SerializeField] private int _health;

    public int Speed => _speed;

    public int Health => _health;

    public Sprite EntitySprite => _entitySprite;
}
