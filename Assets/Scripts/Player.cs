using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider2;

    private int Speed = 2;
    private int JumpStrength = 5;
    private Vector2 direction;

    private void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal") * Speed;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction.y = JumpStrength;
        }
        else
        {
            direction.y = rigidBody.velocity.y;
        }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2 = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = direction;
    }
}
