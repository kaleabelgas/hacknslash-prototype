using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : ScriptableObject
{
    [SerializeField] private int speed;
    [SerializeField] private int health;
    [SerializeField] private int armor;

    public int Speed => speed;

    public int Health => health;

    public int Armor => armor;

}
