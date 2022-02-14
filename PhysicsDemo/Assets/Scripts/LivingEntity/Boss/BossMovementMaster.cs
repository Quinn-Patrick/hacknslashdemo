using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementMaster : MonoBehaviour, IMovementMaster
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] protected MovementController _movement;
    [SerializeField] protected SpeedSystem _speedSystem;
    [SerializeField] protected GravitySystem _gravitySystem;
    [SerializeField] protected InputReader _inputReader;

    void Awake()
    {
        _movement = gameObject.GetComponent<MovementController>();
        _speedSystem = gameObject.GetComponent<SpeedSystem>();
        _gravitySystem = gameObject.GetComponent<GravitySystem>();
        _inputReader = gameObject.GetComponent<InputReader>();
        _characterController = gameObject.GetComponent<CharacterController>();
        if (_speedSystem != null)
        {
            _speedSystem.SetBaseSpeed(5f);
        }
    }

    void Update()
    {
        MovementLogic();
    }

    public void MovementLogic()
    {
        Vector3 speed = _speedSystem.ComputeSpeed(new Vector3(_inputReader.GetLeftRightMovement(), 0f, _inputReader.GetForwardBackMovement()));
        _characterController.Move(speed);
        _gravitySystem.Gravitate(_characterController);
    }

    public Vector3 GetSpeed()
    {
        return _speedSystem.GetCurrentSpeed();
    }

    public IKnockbackSystem GetKnockbackSystem()
    {
        return null;
    }

    public SpeedSystem GetSpeedSystem()
    {
        return _speedSystem;
    }

    public MovementController GetMovementSystem()
    {
        return _movement;
    }
}
