using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.1f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        _velocity = new Vector2(inputX, inputY) * movementSpeed;
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _velocity;
    }
}
