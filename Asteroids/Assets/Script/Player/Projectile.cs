using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D body;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask layer = collision.gameObject.layer;
        
        if (layer == 6)
        {
            GameManeger.instance.IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (body.position.y >= 11f)
            Destroy(gameObject);
        if (body.position.y <= -11f)
            Destroy(gameObject);
        if (body.position.x >= 23f)
            Destroy(gameObject);
        if (body.position.x <= -23f)
            Destroy(gameObject);
    }

}
