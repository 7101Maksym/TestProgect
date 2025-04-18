using UnityEngine;

public class InputGetter : MonoBehaviour
{
	private float _horisontal;
    private float _vertical;
    private float _dash;
    private float _run;
    private float _shoot;

    public float Horisontal
    {
        get
        {
            return _horisontal;
        }
        private set
        {
            _horisontal = value;
        }
    }

    public float Vertical
    {
        get
        {
            return _vertical;
        }
        private set
        {
            _vertical = value;
        }
    }

    public float Dash
    {
        get
        {
            return _dash;
        }
        private set
        {
            _dash = value;
        }
    }

    public float Run
    {
        get
        {
            return _run;
        }
        private set
        {
            _run = value;
        }
    }

    public float Shoot
    {
        get
        {
            return _shoot;
        }
        private set
        {
            _shoot = value;
        }
    }

    private void Update()
	{
		_horisontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _dash = Input.GetAxisRaw("Dash");
        _run = Input.GetAxisRaw("Run");
        _shoot = Input.GetAxisRaw("Shoot");
    }
}
