using UnityEngine;

public class InputGetter : MonoBehaviour
{
	private float _horisontal;
    private float _vertical;
    private float _dash;

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

    private void Update()
	{
		_horisontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _dash = Input.GetAxisRaw("Dash");
    }
}
