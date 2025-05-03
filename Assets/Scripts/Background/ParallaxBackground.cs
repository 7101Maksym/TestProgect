using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Camera _main_camera;
    private Transform _main_camera_transform;
    [SerializeField] private float _parallax_factor = 1f;

    private void Awake()
    {
        if (_main_camera is null)
        {
            _main_camera = Camera.main;
        }

        _main_camera_transform = _main_camera.transform;
    }

    private void LateUpdate()
    {
        gameObject.transform.position = new Vector3(_main_camera_transform.position.x * _parallax_factor, _main_camera_transform.position.y * _parallax_factor);
    }
}
