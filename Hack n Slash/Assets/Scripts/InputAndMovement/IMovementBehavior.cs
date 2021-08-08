using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBehavior
{
    void SetMovement(Vector2 direction);
    void SetMoveSpeed(float moveSpeed);
}
