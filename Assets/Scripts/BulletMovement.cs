using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = Constants.Bullet.DefaultSpeed;        
    }

    private void Update()
    {
        _rb.MovePosition(transform.position + transform.up * _speed * Time.deltaTime);
    }
}
