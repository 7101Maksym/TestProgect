using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
	private InputGetter _input;
	private Rigidbody2D _rigid_body;

	private float _normal_speed = 2f;
	private float _horizontal;

	private Vector2 _velocity;

	private float _jump_speed = 5f;
    private float _vertical;
    private bool _in_jump = false, _in_double_jump = false, _can_double_jump = false;
	private LayerMask _LayerMask = new LayerMask();

	private bool _is_dashing = false, _can_dash = true, _dash = false;
	private float _dash_direction = 1, _dash_speed = 10f;
	public delegate void DashStarted();
	public event DashStarted StartDash;

	private void DoubleJump()
	{
		if (Physics2D.Raycast(transform.position, -transform.up, 0.4f, _LayerMask))
		{
			_in_jump = false;
			_in_double_jump = false;
			_can_double_jump = false;
        }

        if (_vertical > 0 && Physics2D.Raycast(transform.position, -transform.up, 0.4f, _LayerMask) && _in_jump == false)
		{
			_velocity.y = _vertical * _jump_speed;
			_in_jump = true;
		}
		else if (_vertical > 0 && _in_jump == true && _in_double_jump == false && _can_double_jump)
		{
            _velocity.y = _vertical * _jump_speed;
            _in_double_jump = true;
        }

		if (!(_vertical > 0))
		{
			_can_double_jump = true;
		}
    }

	private void NormalMove()
	{
		_velocity = new Vector2(_horizontal * _normal_speed, _rigid_body.velocity.y);
	}

	private void Dash()
	{
		if (_dash && _can_dash)
		{
			_can_dash = false;
			_is_dashing = true;

			Invoke(nameof(FinishDash), 0.2f);
		}
	}

	private void FinishDash()
	{
		_is_dashing = false;
		Invoke(nameof(CanDash), 3);
	}

	private void CanDash()
	{
		_can_dash = true;
	}

	private void Move()
	{
		Dash();

		if (!_is_dashing)
		{
			NormalMove();
			DoubleJump();
		}
		else
		{
            _velocity = new Vector2(_dash_speed * _dash_direction, _rigid_body.velocity.y);
        }

        _rigid_body.velocity = _velocity;
    }

	private void Awake()
	{
        _LayerMask.value = LayerMask.GetMask("Ground");

        _input = GetComponent<InputGetter>();
		_rigid_body = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        _horizontal = _input.Horisontal;
		_vertical = _input.Vertical;

		if (_horizontal != 0 && _horizontal != _dash_direction)
		{
			_dash_direction = _horizontal;
		}

		if (_input.Dash > 0)
		{
			_dash = true;
		}
		else
		{
			_dash = false;
		}
    }

    private void FixedUpdate()
	{
		Move();
    }
}
