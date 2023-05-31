using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid : MonoBehaviour
{
    public SpawnManeger SpawnManeger;
    public GameObject center;
    public float speed;
    public Rigidbody2D body;

    void Update()
    {
        //creating a constant speed
        transform.position += transform.up * (Time.deltaTime * speed);
        float distance = Vector3.Distance(transform.position, center.transform.position);

        // destroys when out of bounds
        if (distance > SpawnManeger.killradius)
        {
            Destroy(gameObject);
        }
    }
}
