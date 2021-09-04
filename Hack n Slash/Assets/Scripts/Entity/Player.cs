using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Entity/Player")]
public class Player : ScriptableObject
{
    [SerializeField] private int speed;
    [SerializeField] private int health;
    [SerializeField] private int armor;
    [SerializeField] private Team team;

    public int Speed => speed;

    public int Health => health;

    public int Armor => armor;

    public Team Team => team;

    public void SetTeam(Team team)
    {
        this.team = team;
    }

}
