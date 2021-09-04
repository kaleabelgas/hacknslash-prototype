using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField] private Player player;
    public Player Player
    {
        get => player;
        set => player = value;
    }
}
