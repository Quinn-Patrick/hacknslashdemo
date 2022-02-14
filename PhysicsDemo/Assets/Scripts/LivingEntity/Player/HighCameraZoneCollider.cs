using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighCameraZoneCollider : MonoBehaviour, ITriggerCollider
{
    [SerializeField] private ICamera _camera;
    [SerializeField] private float _highCamera = 5f;
    [SerializeField] private float _lowCamera = 30f;

    private void Awake()
    {
        _camera = Camera.main.GetComponent<ICamera>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HighCameraZone") && _camera != null)
        {
            _camera.SetTargetTheta(_highCamera);
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("HighCameraZone") && _camera != null)
        {
            _camera.SetTargetTheta(_lowCamera);
        }
    }
}
