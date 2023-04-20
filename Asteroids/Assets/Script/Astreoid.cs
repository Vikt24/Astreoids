using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid : MonoBehaviour
{
    public float speed, size, diraktion;
    public Rigidbody2D body;

    void Update()
    {
        body.velocity = new Vector2(speed, 0);
    }
}
