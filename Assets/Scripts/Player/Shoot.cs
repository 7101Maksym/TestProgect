using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private InputGetter _input;
    private PlayerStates _states;

    private void Awake()
    {
        _input = GetComponent<InputGetter>();
        _states = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        if (_input.Shoot > 0)
        {
            _states._shoot = true;
        }
        else
        {
            _states._shoot = false;
        }
    }
}
