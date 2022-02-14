using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMaster : MonoBehaviour, IMovementMaster
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] protected IKnockbackSystem _knockback;
    [SerializeField] protected MovementController _movement;
    [SerializeField] protected SpeedSystem _speedSystem;
    [SerializeField] protected GravitySystem _gravitySystem;
    [SerializeField] protected InputReader _inputReader;
    void Awake()
    {
        _movement = gameObject.GetComponent<MovementController>();
        _speedSystem = gameObject.GetComponent<SpeedSystem>();
        _gravitySystem = gameObject.GetComponent<GravitySystem>();
        _knockback = gameObject.GetComponent<IKnockbackSystem>();
        _inputReader = gameObject.GetComponent<InputReader>();
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        MovementLogic();
    }

    public Vector3 GetSpeed()
    {
        if (_speedSystem != null)
        {
            return _speedSystem.GetCurrentSpeed();
        }
        else
        {
            return Vector3.zero;
        }
    }

    public void MovementLogic()
    {
        if (_characterController == null || !_characterController.enabled || _inputReader == null)
        {
            return;
        }

        float x = -_inputReader.GetLeftRightMovement();
        float z = -_inputReader.GetForwardBackMovement();

        if (_speedSystem != null && _movement != null)
        {
            Vector3 stepSpeed = Vector3.zero;
            if (_knockback != null)
            {
                stepSpeed = _knockback.GetKnockbackSpeed();
            }

            Vector3 intermediateSpeed = _speedSystem.ComputeSpeed(new Vector3(x, 0f, z));

            _movement.Translate(new Vector3((intermediateSpeed.x + stepSpeed.x) * Time.deltaTime, 0f, (intermediateSpeed.z + stepSpeed.z) * Time.deltaTime));
        }

        if (_gravitySystem != null)
        {
            _gravitySystem.Gravitate(_characterController);
        }
    }

    public IKnockbackSystem GetKnockbackSystem()
    {
        return _knockback;
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
