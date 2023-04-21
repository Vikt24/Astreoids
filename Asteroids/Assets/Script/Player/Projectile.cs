using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask layer = collision.gameObject.layer;
        
        if (layer == 6)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
