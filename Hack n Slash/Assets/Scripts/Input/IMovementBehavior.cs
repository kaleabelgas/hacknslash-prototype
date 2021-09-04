using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBehavior
{
    void SetMovementDirection(Vector2 direction);
    void SetMoveSpeed(float moveSpeed);
}
