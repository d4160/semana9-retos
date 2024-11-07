using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.right = _rigidbody2D.linearVelocity;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody2D.linearVelocity = velocity;
    }
}
