using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(PlayerMove))]

public class Animation : MonoBehaviour
{
    private Animator _animator;
    private InputGetter _input;
    private PlayerController _controller;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<PlayerController>();
        _input = GetComponent<InputGetter>();
    }

    public void RotatePlayer()
    {
        if (_input.Horisontal != 0)
        {
            Vector3 LocalScale = _input.gameObject.transform.localScale;
            LocalScale.x = Mathf.Sign(_input.Horisontal);
            _input.gameObject.transform.localScale = LocalScale;
        }
    }

    public void PlayWake()
    {
        _animator.SetBool("IsRun", false);
    }

    public void PlayRun()
    {
        _animator.SetBool("IsRun", true);
    }

    public void PlayShoot()
    {
        _animator.SetBool("Shoot", true);
    }

    public void StopShoot()
    {
        _animator.SetBool("Shoot", false);
    }
}
