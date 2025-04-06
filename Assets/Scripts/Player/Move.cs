using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
	private InputGetter _input;
	private Rigidbody2D _rigid_body;
    private PlayerStates _states;

	private float _normal_speed = 2f;
	private float _horizontal;

	private Vector2 _velocity;

    [SerializeField] private float _walk_speed = 2f;
    [SerializeField] private float _run_speed = 3f;

	private void NormalMove()
	{
		_velocity = new Vector2(_horizontal * _normal_speed, _rigid_body.velocity.y);
        _rigid_body.velocity = _velocity;
	}

	private void Move()
	{
		if (!_states._is_dashing)
		{
			NormalMove();
		}
    }

	private void Awake()
	{
        _input = GetComponent<InputGetter>();
		_rigid_body = GetComponent<Rigidbody2D>();
        _states = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        if (_input.Run > 0)
        {
            _normal_speed = _run_speed;
        }
        else
        {
            _normal_speed = _walk_speed;
        }

        _horizontal = _input.Horisontal;
    }

    private void FixedUpdate()
	{
		Move();
    }
}
