using UnityEngine;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(PlayerMove))]

public class Animation : MonoBehaviour
{
    private PlayerMove _move;
    private InputGetter _input;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _input = GetComponent<InputGetter>();

        _move.StartDash += PlayDash;
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void OnDestroy()
    {
        _move.StartDash -= PlayDash;
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

    private void PlayDash()
    {

    }
}
