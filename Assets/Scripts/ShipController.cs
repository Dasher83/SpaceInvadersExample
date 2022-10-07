using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _shootingSound;
    [SerializeField]
    private AudioSource _accelerating;
    [SerializeField]
    private AudioSource _slowingDown;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private float _maxSpeedSquared;
    private float _previousSquaredSpeed;

    [SerializeField]
    private float movementSpeed;

    private float MovementSpeed { 
        get
        {
            if(movementSpeed > _maxSpeedSquared)
            {
                return _maxSpeedSquared;
            }
            return movementSpeed;
        } 
    }

    private void LimitMoveSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeedSquared)
        {
            _rb.velocity = _rb.velocity.normalized * (_maxSpeedSquared - ((Vector2)_movement * MovementSpeed).magnitude);
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
        _maxSpeedSquared = Constants.Ship.MaxSpeed * Constants.Ship.MaxSpeed;
        movementSpeed = Constants.Ship.DefaultMovementSpeed;
        _previousSquaredSpeed = 0f;
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

        if (_previousSquaredSpeed > _movement.sqrMagnitude && !_slowingDown.isPlaying)
        {
            _accelerating.Stop();
            _slowingDown.Play();
        }

        if((_previousSquaredSpeed < _movement.sqrMagnitude || _movement.sqrMagnitude == _maxSpeedSquared) && !(_slowingDown.isPlaying && _accelerating.isPlaying))
        {
            _accelerating.Play();
        }

        _previousSquaredSpeed = _movement.sqrMagnitude;
    }

    private void FixedUpdate()
    {
        LimitMoveSpeed();
        _rb.AddForce(_movement * MovementSpeed);
    }
}
