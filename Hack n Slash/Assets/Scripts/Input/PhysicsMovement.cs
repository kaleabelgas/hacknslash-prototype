using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour, IMovementBehavior
{
    [SerializeField] private bool doesFlipObject;

    private Rigidbody2D _rb2D;

    private float _moveSpeed;
    private Vector2 _direction;
    private bool _isFacingRight = true;

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public void SetMovement(Vector2 direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        _rb2D.MovePosition(_rb2D.position + _moveSpeed * Time.deltaTime * _direction);

        if(!doesFlipObject)
        {
            return;
        }

        if (_direction.x < 0 && _isFacingRight)
        {
            Flip();
        }
        else if (_direction.x > 0 && !_isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
