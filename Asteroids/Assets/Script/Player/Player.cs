using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject prefab, gun;
    Vector3 newRot;
    Quaternion gunRot;
    public float speed, rotation, attackSpeed;
    private float coldown, changeInRot, pos;

    private void Start()
    {
        changeInRot = gameObject.transform.rotation.z;
    }

    void Update()
    {
        pos = gameObject.transform.position.x;

        coldown -= 0.1f;
        if (coldown<= 0)
            coldown = 0;


        if (Input.GetKeyDown(KeyCode.W))
            body.velocity += new Vector2 (body.velocity.x, speed);
        if (Input.GetKeyDown(KeyCode.A))
        {
            pos -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pos += 1;
        }
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    changeInRot += rotation;
            //}
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    changeInRot -= rotation;
            //}
            //newRot = new Vector3(0, 0, changeInRot);
            //gunRot = Quaternion.Euler(newRot);
            //transform.localEulerAngles = newRot;
            //gun.transform.rotation = gunRot;

        if (Input.GetKeyDown(KeyCode.Q) && coldown == 0)
        {
            Attack();
            coldown += attackSpeed;
        }

        gameObject.transform.position = new Vector2(pos, gameObject.transform.position.y);

    }

    private void Attack() 
    {
        Instantiate(prefab, body.position, body.transform.rotation);
    }

}
