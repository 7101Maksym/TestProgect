using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public bool _is_dashing = false;

    public bool _is_running = false;

    public bool _in_jump = false, _in_double_jump = false, _can_double_jump = false, can_jump = true;
}
