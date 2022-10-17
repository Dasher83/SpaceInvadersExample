using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private float _bulletDamage;

    private float OverallInflictedDamage
    {
        get
        {
            return _bulletDamage;
        }
    }

    private void Start()
    {
        _bulletDamage = Constants.Bullet.InitialBulletDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>().ReceiveDamage(OverallInflictedDamage);
        Destroy(gameObject);
    }
}
