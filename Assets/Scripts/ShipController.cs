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

    private void StartAtRandomPosition()
    {
        float leftLimit = GameObject.Find(Constants.GameObjects.LeftOuterBound).transform.position.x;
        float rightLimit = GameObject.Find(Constants.GameObjects.RightOuterBound).transform.position.x;
        float spriteWidthOffset = this.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float randomX = Random.Range(leftLimit + spriteWidthOffset, rightLimit - spriteWidthOffset);
        this.transform.position = GameObject.Find(Constants.GameObjects.ShipSpawnPoint).transform.position;
        Vector3 newPosition = this.transform.position;
        newPosition.x = randomX;
        this.transform.position = newPosition;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = Constants.Ship.MaxSpeed;
        movementSpeed = Constants.Ship.DefaultMovementSpeed;
        StartAtRandomPosition();
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
