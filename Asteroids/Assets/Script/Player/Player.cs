using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject prefab, deathScreen, menuScreen;
    public Transform gun;
    public Camera cam;
    private Vector2 mosePos;
    public float speed, rotation, attackSpeed, projektileSpeed;
    private float coldown;

    private void FixedUpdate()
    {
        Vector2 lookDir = mosePos - body.position;
        float ange = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        body.rotation = ange;
    }

    void Update()
    {
        coldown -= 0.1f * Time.deltaTime;
        if (coldown<= 0)
            coldown = 0;

        mosePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        //movment
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horInput * speed, vertInput * speed);
        //speed limits
        if (body.velocity.x >= 9)
            body.velocity = new Vector2(9, body.velocity.y);
        if (body.velocity.x <= -9)
            body.velocity = new Vector2(-9, body.velocity.y);
        if (body.velocity.y >= 9)
            body.velocity = new Vector2(body.velocity.x, 9);
        if (body.velocity.y <= -9)
            body.velocity = new Vector2(body.velocity.x, -9);

        //attack function
        if (Input.GetKeyDown(KeyCode.Q) && coldown == 0 || Input.GetKeyDown(KeyCode.Mouse0) && coldown == 0)
        {
            Attack();
            coldown += attackSpeed * Time.deltaTime;
        }

        //screen teleportation (top to bottttom and left to right)
        BorderCheck();
    }

    private void Attack() 
    {
        //fires gun
        GameObject projektile = Instantiate(prefab, body.position, body.transform.rotation);
        Rigidbody2D rb = projektile.GetComponent<Rigidbody2D>();
        rb.AddForce(gun.up * projektileSpeed, ForceMode2D.Impulse);
    }

    private void BorderCheck()
    {
        // if player is outside from the 
        Vector3 pos = cam.WorldToViewportPoint(transform.position);
        
        if (pos.y > 1.0f) // Top
            body.position = cam.ViewportToWorldPoint(new(pos.x, 0f));
        if (pos.y < 0f) // Bottom
            body.position = cam.ViewportToWorldPoint(new(pos.x, 1f));
        if (pos.x > 1.0f) // Right
            body.position = cam.ViewportToWorldPoint(new(0f, pos.y));
        if (pos.x < 0f) // Left
            body.position = cam.ViewportToWorldPoint(new(1f, pos.y));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask layer = collision.gameObject.layer;

        //cheking if player is colliding with atreoids
        if (layer == 6)
        {
            menuScreen.SetActive(false);
            deathScreen.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}