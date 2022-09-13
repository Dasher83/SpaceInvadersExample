using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float maxSpeed;

    [SerializeField]
    private float movementSpeed;

    private float MovementSpeed { 
        get
        {
            if(movementSpeed > maxSpeed)
            {
                return maxSpeed;
            }
            return movementSpeed;
        } 
    }

    private void LimitMoveSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * (maxSpeed - ((Vector2)movement * MovementSpeed).magnitude);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = Constants.Ship.MaxSpeed;
        movementSpeed = Constants.Ship.DefaultMovementSpeed;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis(Constants.Axes.Horizontal);
        movement = new Vector2(moveHorizontal, 0f);
    }

    private void FixedUpdate()
    {
        LimitMoveSpeed();
        rb.AddForce(movement * MovementSpeed);
    }
}
