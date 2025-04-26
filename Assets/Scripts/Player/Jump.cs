using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigid_body;
    private PlayerController _controller;
    private InputGetter _input;

    [SerializeField] private Vector2 _velocity;

    [SerializeField] private float _jump_speed = 5f;
    [SerializeField] private float _vertical;
    private LayerMask _LayerMask = new LayerMask();

    public bool _in_jump = false, _in_double_jump = false, _can_double_jump = false, can_jump = true;

    private void DoubleJump()
    {
        if (can_jump)
        {
            _in_jump = false;
            _in_double_jump = false;
            _can_double_jump = false;

            if (_vertical > 0 && _in_jump == false)
            {
                _velocity.y = _vertical * _jump_speed;

                _in_jump = true;
            }
        }
        else
        {
            if (_vertical > 0 && _in_jump == true && _in_double_jump == false && _can_double_jump)
            {
                _velocity.y = _vertical * _jump_speed;
                _in_double_jump = true;
            }
        }

        if (!(_vertical > 0))
        {
            _can_double_jump = true;
        }
    }

    private void Awake()
    {
        _LayerMask.value = LayerMask.GetMask("Ground");

        _input = GetComponent<InputGetter>();
        _rigid_body = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 0.4f, _LayerMask) && _controller.MoveState != States.Dash)
        {
            can_jump = true;
        }
        else
        {
            can_jump = false;
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

