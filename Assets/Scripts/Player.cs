using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	private Rigidbody2D rigidBody;
	private SpriteRenderer sprite;

	private int Speed = 2;
	private int JumpStrength = 5;
	private Vector2 direction;

	private void Move()
	{
		direction.x = Input.GetAxisRaw("Horizontal");

		switch (direction.x)
		{
			case 1:
				sprite.flipX = false;
				break;
			case -1:
				sprite.flipX = true;
				break;
			default:
				break;
		}

		Vector2 p = new Vector2(sprite.transform.position.x, sprite.transform.position.y - 0.26f);
		Debug.DrawRay(p, -transform.up);

        if (Input.GetAxisRaw("Vertical") > 0 && Physics2D.Raycast(p, -transform.up, 0.05f))
		{
			direction.y = 1;
		}
		else
		{
			direction.y = 0;
		}
	}

	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>(true);
	}

	private void Update()
	{
		Move();
	}

	private void FixedUpdate()
	{
		rigidBody.velocity = new Vector2(direction.x * Speed, rigidBody.velocity.y + direction.y * JumpStrength);
		Debug.Log(rigidBody.velocity.y);
	}
}
