using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Potion")]
public class Potion : Item
{
    [SerializeField] private StatType type;
    [SerializeField] private int amount;

    public override void Use(GameObject usedBy)
    {
        usedBy.GetComponent<StatsManager>().AddToStat(type, amount);
    }
}
