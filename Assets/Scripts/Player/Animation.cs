using UnityEngine;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(PlayerMove))]

public class Animation : MonoBehaviour
{
    private InputGetter _input;
    private PlayerStates _states;
    private Animator _animator;

    private void Awake()
    {
        _states = GetComponent<PlayerStates>();
        _animator = GetComponentInChildren<Animator>();
        _input = GetComponent<InputGetter>();
    }

    private void Update()
    {
        RotatePlayer();
        SetAnimation();
    }

    private void RotatePlayer()
    {
        if (_input.Horisontal != 0)
        {
            Vector3 LocalScale = _input.gameObject.transform.localScale;
            LocalScale.x = Mathf.Sign(_input.Horisontal);
            _input.gameObject.transform.localScale = LocalScale;
        }
    }

    private void SetAnimation()
    {
        _animator.SetBool("IsRun", _states._is_moving);
        _animator.SetBool("Shoot", _states._shoot);
    }
}
