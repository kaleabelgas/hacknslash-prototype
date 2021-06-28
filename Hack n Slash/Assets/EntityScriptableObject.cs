using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Entity", menuName = "Scriptable Object/Entity")]
public class EntityScriptableObject : ScriptableObject
{
    public int Speed;
    public int Health;
}
