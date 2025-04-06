using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rigid_body2D;
    private InputGetter _input;
    private PlayerStates _states;


    private bool _can_dash = true, _dash = false;
    private float _dash_direction = 1, _dash_speed = 10f;
    [SerializeField] private float DashLength;
    [SerializeField] private float DashCooldown;
    private float _horizontal;

    private void Dash()
    {
        if (_dash && _can_dash)
        {
            _can_dash = false;
            _states._is_dashing = true;

            Invoke(nameof(FinishDash), DashLength);
        }
    }

    private void FinishDash()
    {
        _states._is_dashing = false;
        Invoke(nameof(CanDash), DashCooldown);
    }

    private void CanDash()
    {
        _can_dash = true;
    }

    private void Awake()
    {
        _rigid_body2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputGetter>();
        _states = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        _horizontal = _input.Horisontal;

        if (_horizontal != 0 && _horizontal != _dash_direction && _states._is_dashing == false)
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
        Dash();

        if (_states._is_dashing)
        {
            _rigid_body2D.velocity = new Vector2(_dash_speed * _dash_direction, _rigid_body2D.velocity.y);
        }
    }
}
