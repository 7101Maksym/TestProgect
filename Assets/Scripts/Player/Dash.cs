using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rigid_body2D;
    private PlayerController _controller;

    private bool _can_dash = true;

    private float _dash_speed = 10f;
    public float _dash_direction = 1;
    [SerializeField] private float _DashLength = 0.2f;
    [SerializeField] private float _DashCooldown = 3;

    private void Awake()
    {
        _rigid_body2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }

    public void TryDash()
    {
        if (_can_dash && _controller.MoveState != States.Dash && _controller.MoveState != States.Shoot)
        {
            _can_dash = false;
            _controller.MoveState = States.Dash;
            Invoke(nameof(FinishDash), _DashLength);
        }
    }

    public void Dash()
    {
        _rigid_body2D.velocity = new Vector2(_dash_speed * _dash_direction, _rigid_body2D.velocity.y);
    }

    private void FinishDash()
    {
        _controller.MoveState = States.Wake;
        Invoke(nameof(DashCooldown), _DashCooldown);
    }

    private void DashCooldown()
    {
        _can_dash = true;
    }

    public void SetDashDirection(float dash_dir)
    {
        _dash_direction = dash_dir;
    }
}
