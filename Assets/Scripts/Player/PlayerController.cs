using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private InputGetter _input;
	private Shoot _shoot;
	private PlayerMove _move;
	private PlayerJump _jump;
	private Animation _animation;
	private PlayerDash _dash;

	public States JumpState = States.OnGround;
	public States MoveState = States.Wake;

    [SerializeField] private Vector2 _velocity;

    private void Awake()
	{
		_input = GetComponent<InputGetter>();
		_animation = GetComponent<Animation>();
		_dash = GetComponent<PlayerDash>();
		_move = GetComponent<PlayerMove>();
		_jump = GetComponent<PlayerJump>();
		_shoot = GetComponent<Shoot>();
	}

	private void Update()
	{
		if (MoveState != States.Shoot)
		{
			SetMoveState();
		}

        if (MoveState != States.Shoot && MoveState != States.Dash)
        {
            _animation.RotatePlayer();
        }

        switch (MoveState)
        {
            case States.Wake:
                _animation.PlayWake();
                break;
            case States.Shoot:
                _animation.PlayShoot();
                break;
            case States.Walk:
                _animation.PlayRun();
                break;
            case States.Run:
                _animation.PlayRun();
                break;
        }
    }

    private void FixedUpdate()
    {
        if (MoveState != States.Shoot && MoveState != States.Dash)
        {
            _animation.RotatePlayer();
        }

        switch (MoveState)
        {
            case States.Wake:
                _move.SetZeroSpeed();
                _move.NormalMove(_input.Horisontal);
                break;
            case States.Shoot:
                _move.SetZeroSpeed();
                _move.NormalMove(_input.Horisontal);
                break;
            case States.Walk:
                _move.SetWalkSpeed();
                _move.NormalMove(_input.Horisontal);
                break;
            case States.Run:
                _move.SetRunSpeed();
                _move.NormalMove(_input.Horisontal);
                break;
            case States.Dash:
                _dash.Dash();
                break;
        }
    }

    private void SetMoveState()
	{
        if (_input.Dash != 0)
        {
            _dash.TryDash();
        }

        if (_input.Shoot != 0)
        {
            _shoot.TryShoot();
        }

        if (MoveState != States.Shoot)
        {
            if (_input.Horisontal != 0)
            {
                if (MoveState != States.Dash)
                {
                    if (_input.Horisontal != _dash._dash_direction)
                    {
                        _dash.SetDashDirection(_input.Horisontal);
                    }
                    if (_input.Run != 0)
                    {
                        MoveState = States.Run;
                    }
                    else
                    {
                        MoveState = States.Walk;
                    }
                }
            }
            else if (MoveState != States.Dash)
            {
                MoveState = States.Wake;
            }
        }
	}
}
