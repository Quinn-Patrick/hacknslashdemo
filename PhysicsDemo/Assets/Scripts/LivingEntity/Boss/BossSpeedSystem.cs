using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeedSystem : MonoBehaviour, SpeedSystem
{
    private float _baseMovement;
    private Vector3 _speed;
    public Vector3 ComputeSpeed(Vector3 inputs)
    {
        _speed = new Vector3(_baseMovement * -inputs.x * Time.deltaTime, 0f, _baseMovement * inputs.z * Time.deltaTime);
        return _speed;
    }

    public float GetBaseSpeed()
    {
        return _baseMovement;
    }

    public Vector3 GetCurrentSpeed()
    {
        return _speed;
    }

    public float GetRootSpeed()
    {
        return _baseMovement;
    }

    public void SetBaseSpeed(float baseSpeed)
    {
        _baseMovement = baseSpeed;
    }
}
