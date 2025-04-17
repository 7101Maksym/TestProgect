using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(InputGetter))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigid_body;

    private float _normal_speed = 2f;

    private Vector2 _velocity;

    [SerializeField] private float _walk_speed = 2f;
    [SerializeField] private float _run_speed = 3f;

    public void NormalMove(float _horizontal)
    {
        _velocity = new Vector2(_horizontal * _normal_speed, _rigid_body.velocity.y);
        _rigid_body.velocity = _velocity;
    }

    private void Awake()
    {
        _rigid_body = GetComponent<Rigidbody2D>();
    }

    public void SetZeroSpeed()
    {
        _normal_speed = 0;
    }
    public void SetRunSpeed()
    {
        _normal_speed = _run_speed;
    }
    public void SetWalkSpeed()
    { 
        _normal_speed = _walk_speed;
    }
}
