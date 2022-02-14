using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour, InputReader
{
    private float _leftRightMovement;
    private float _forwardBackMovement;
    private bool _sprint;
    private bool _attack;
    private bool _directionalNeutralized;
    private bool _generalNeutralized;

    [SerializeField] private Controller _input;

    void Update()
    {
        ReadInputs();
    }
    private void ReadInputs()
    {
        if (_input == null)
        {
            NeutralizeInputs();
        }
        else if(!_generalNeutralized)
        {
            if (!_directionalNeutralized)
            {
                _forwardBackMovement = _input.getForwardMovement();
                _leftRightMovement = _input.getSidewaysMovement();
            }
            _sprint = _input.getSprint();
            _attack = _input.getAttack(); 
        }
        _directionalNeutralized = false;
        _generalNeutralized = false;
    }

    public float GetForwardBackMovement()
    {
        return _forwardBackMovement;
    }
    public float GetLeftRightMovement()
    {
        return _leftRightMovement;
    }
    public bool GetSprint()
    {
        return _sprint;
    }
    public bool GetAttack() 
    {
        return _attack;
    }
    public void NeutralizeInputs()
    {
        NeutralizeDirectionalInputs();
        _sprint = false;
        _attack = false;
        _generalNeutralized = true;
    }

    public void NeutralizeDirectionalInputs()
    {        
        _forwardBackMovement = 0;
        _leftRightMovement = 0;
        _directionalNeutralized = true;
    }
}
