using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Scriptable Object/Entity")]
public class Entity : ScriptableObject
{
    [SerializeField]
    private Sprite entitySprite;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int health;

    public int Speed => speed;

    public int Health => health;

    public Sprite EntitySprite => entitySprite;
}
