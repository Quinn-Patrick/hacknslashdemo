using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintSystem : MonoBehaviour, ISprintSystem
{
    [SerializeField] private InputReader _input;
    [SerializeField] private SpeedSystem _speedSystem;
    [SerializeField] private float _sprintMultiplier = 2f;
    private bool _isSprinting = false;

    private void Awake()
    {
        _input = gameObject.GetComponent<InputReader>();
        _speedSystem = gameObject.GetComponent<SpeedSystem>();
    }

    void Update()
    {
        Sprint();
    }

    public void Sprint()
    {
        if (_input.GetSprint())
        {
            _speedSystem.SetBaseSpeed(_speedSystem.GetRootSpeed() * _sprintMultiplier);
            _isSprinting = true;
        }
        else
        {
            _speedSystem.SetBaseSpeed(_speedSystem.GetRootSpeed());
            _isSprinting = false;
        }
    }

    public bool IsSprinting()
    {
        return _isSprinting;
    }
}
