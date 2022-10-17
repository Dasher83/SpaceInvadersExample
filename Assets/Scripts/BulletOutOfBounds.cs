using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOutOfBounds : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y - GetComponent<SpriteRenderer>().size.y / 2 > Utils.OrthographicBounds().max.y)
        {
            Destroy(gameObject);
        }            
    }
}
