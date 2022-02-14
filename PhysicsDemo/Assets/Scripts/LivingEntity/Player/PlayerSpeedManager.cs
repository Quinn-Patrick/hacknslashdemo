using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedManager : MonoBehaviour, SpeedSystem
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _acceleration = 64f;
    private Vector3 _speed = Vector3.zero;
    [SerializeField] private float _friction = 64f;
    [SerializeField] private float _tolerance = 0.000001f;
    [SerializeField] private readonly float _rootSpeed = 6f;

    public Vector3 ComputeSpeed(Vector3 inputs)
    {
        ComputeSpeedFromInputs(inputs);
        LimitSpeed();
        ZeroInputFriction(inputs);
        MinimizeSpeedToZero(inputs);

        return _speed;
    }

    private void ComputeSpeedFromInputs(Vector3 inputs)
    {
        float x = inputs.x;
        float z = inputs.z;

        if (_speed.magnitude < _baseSpeed + 1.0f)
        {
            _speed += new Vector3(x * Time.deltaTime * _acceleration, 0f, z * Time.deltaTime * _acceleration);
        }
    }

    private void LimitSpeed()
    {
        if (_speed.magnitude > _baseSpeed)
        {
            if (_speed.magnitude < _baseSpeed + 0.5)
            {
                _speed *= _baseSpeed / _speed.magnitude;
            }
            else
            {
                _speed -= new Vector3(_speed.normalized.x * _acceleration * Time.deltaTime, 0f, _speed.normalized.z * _acceleration * Time.deltaTime);
            }
        }
    }

    private void ZeroInputFriction(Vector3 inputs)
    {
        float leftRightMovement = inputs.x;
        float forwardBackMovement = inputs.z;
        if (Mathf.Abs(leftRightMovement) < _tolerance && Mathf.Abs(forwardBackMovement) < _tolerance)
        {
            Vector3 normalSpeed = _speed.normalized;
            _speed -= new Vector3(normalSpeed.x * _friction * Time.deltaTime, 0f, normalSpeed.z * _friction * Time.deltaTime);
        }
    }

    private void MinimizeSpeedToZero(Vector3 inputs)
    {
        float leftRightMovement = inputs.x;
        float forwardBackMovement = inputs.z;
        if (_speed.magnitude < 0.5f && leftRightMovement == 0 && forwardBackMovement == 0)
        {
            _speed = Vector3.zero;
        }
    }

    public void SetBaseSpeed(float baseSpeed)
    {
        _baseSpeed = baseSpeed;
    }

    public float GetBaseSpeed()
    {
        return _baseSpeed;
    }

    public float GetRootSpeed()
    {
        return _rootSpeed;
    }

    public Vector3 GetCurrentSpeed()
    {
        return _speed;
    }
}
