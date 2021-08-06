using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePhysics : MonoBehaviour, IMovement
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private Vector2 direction;
    private bool isFacingRight = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
        //Debug.Log(moveSpeed);
    }
    public void SetMovement(Vector2 direction)
    {
        this.direction = direction;
    }
    private void Move()
    {
        rb2D.MovePosition(rb2D.position + direction * moveSpeed * Time.deltaTime);
        //Debug.Log(moveSpeed, this);

        if (direction.x < 0 && isFacingRight)
            Flip();
        else if (direction.x > 0 && !isFacingRight)
            Flip();

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
