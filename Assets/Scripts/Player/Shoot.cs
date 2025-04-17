using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	private PlayerController _controller;
    private Animation _animation;

    [SerializeField] private float ShootLength = 1.1f;

	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
        _animation = GetComponent<Animation>();
    }

	public void TryShoot()
	{
		if (_controller.MoveState != States.Dash && _controller.MoveState != States.Shoot)
		{
			DoShoot();
		}
	}

	private void DoShoot()
	{
		_controller.MoveState = States.Shoot;
		Invoke(nameof(FinishShoot), ShootLength);
	}

	private void FinishShoot()
	{
		_controller.MoveState = States.Wake;
        _animation.StopShoot();
	}
}
