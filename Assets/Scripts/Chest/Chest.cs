using UnityEngine;

public class Chest : MonoBehaviour
{
	Animator _animator;

	public bool can_open = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			can_open = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			can_open = false;
		}
	}

    private void OnTriggerStay(Collider other)
    {
		Debug.Log("stay");
    }

    private void Update()
	{
		if (can_open)
		{
			Debug.Log("Can open");

			if (Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				_animator.SetBool("Open", true);
				Debug.Log("Opened");
			}
		}
	}
}
