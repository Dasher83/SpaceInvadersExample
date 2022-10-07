using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _shootingSound;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private float _maxSpeed;

    [SerializeField]
    private float movementSpeed;

    private float MovementSpeed { 
        get
        {
            if(movementSpeed > _maxSpeed)
            {
                return _maxSpeed;
            }
            return movementSpeed;
        } 
    }

    private void LimitMoveSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * (_maxSpeed - ((Vector2)_movement * MovementSpeed).magnitude);
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
        _rb = GetComponent<Rigidbody2D>();
        _maxSpeed = Constants.Ship.MaxSpeed;
        movementSpeed = Constants.Ship.DefaultMovementSpeed;
        StartAtRandomPosition();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis(Constants.Axes.Horizontal);
        _movement = new Vector2(moveHorizontal, 0f);

        if (Input.GetKey(KeyCode.Space))
        {
            _shootingSound.Play();
        }
    }

    private void FixedUpdate()
    {
        LimitMoveSpeed();
        _rb.AddForce(_movement * MovementSpeed);
    }
}
