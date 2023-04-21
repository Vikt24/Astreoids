using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject prefab;
    public Transform gun;
    public Camera cam;
    private Vector2 mosePos;
    public float speed, rotation, attackSpeed;
    private float coldown;

    private void FixedUpdate()
    {
        Vector2 lookDir = mosePos - body.position;
        float ange = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        body.rotation = ange;
    }

    void Update()
    {
        coldown -= 0.1f;
        if (coldown<= 0)
            coldown = 0;

        mosePos = cam.ScreenToWorldPoint(Input.mousePosition);

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horInput * speed, vertInput * speed);

        if (body.velocity.x >= 9)
            body.velocity = new Vector2(9, body.velocity.y);
        if (body.velocity.x <= -9)
            body.velocity = new Vector2(-9, body.velocity.y);
        if (body.velocity.y >= 9)
            body.velocity = new Vector2(body.velocity.x, 9);
        if (body.velocity.y <= -9)
            body.velocity = new Vector2(body.velocity.x, -9);

        if (Input.GetKeyDown(KeyCode.Q) && coldown == 0)
        {
            Attack();
            coldown += attackSpeed;
        }


    }

    private void Attack() 
    {
        GameObject projektile = Instantiate(prefab, body.position, body.transform.rotation);
        Rigidbody2D rb = projektile.GetComponent<Rigidbody2D>();
        rb.AddForce(gun.up /10, ForceMode2D.Impulse);
    }

}
