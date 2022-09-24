using UnityEngine;

public class Translator : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
