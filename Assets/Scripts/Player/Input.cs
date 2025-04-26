using UnityEngine;

public class InputGetter : MonoBehaviour
{
    public float Horisontal {  get; private set; }

    public float Vertical {  get; private set; }

    public float Dash {  get; private set; }

    public float Run {  get; private set; }

    public float Shoot { get; private set; }

    private void Update()
	{
		Horisontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Dash = Input.GetAxisRaw("Dash");
        Run = Input.GetAxisRaw("Run");
        Shoot = Input.GetAxisRaw("Shoot");
    }
}
