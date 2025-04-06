using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Jump : MonoBehaviour
{
	private PlayerStates _states;
	private Rigidbody2D _rigid_body;
	private InputGetter _input;

    [SerializeField] private Vector2 _velocity;

    [SerializeField] private float _jump_speed = 5f;
    [SerializeField] private float _vertical;
	private LayerMask _LayerMask = new LayerMask();

	private void DoubleJump()
	{
		if (_states.can_jump)
		{
			_states._in_jump = false;
			_states._in_double_jump = false;
			_states._can_double_jump = false;

			if (_vertical > 0 && _states._in_jump == false)
			{
				_velocity.y = _vertical * _jump_speed;
                
				_states._in_jump = true;
			}
		}
        else
        {
            if (_vertical > 0 && _states._in_jump == true && _states._in_double_jump == false && _states._can_double_jump)
            {
                _velocity.y = _vertical * _jump_speed;
                _states._in_double_jump = true;
            }
        }

		if (!(_vertical > 0))
		{
			_states._can_double_jump = true;
		}
	}

	private void Awake()
	{
		_LayerMask.value = LayerMask.GetMask("Ground");

		_input = GetComponent<InputGetter>();
		_rigid_body = GetComponent<Rigidbody2D>();
        _states = GetComponent<PlayerStates>();
    }

	private void FixedUpdate()
	{
		if (Physics2D.Raycast(transform.position, -transform.up, 0.4f, _LayerMask))
		{
			_states.can_jump = true;
		}
		else
		{
			_states.can_jump = false;
		}
        
        _velocity.y = _rigid_body.velocity.y;
        _velocity.x = _rigid_body.velocity.x;

        DoubleJump();

        _rigid_body.velocity = _velocity;
	}

    private void Update()
    {
        _vertical = _input.Vertical;
    }
}
