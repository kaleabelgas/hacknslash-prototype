using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject player;

    private void Start()
    {
        GetComponent<IMovement>().SetMoveSpeed(player.Speed);
    }
}
