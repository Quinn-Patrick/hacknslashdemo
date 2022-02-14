using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaggerSystem : MonoBehaviour, IStaggerSystem
{
    private float _staggerAmount = 0f;
    [SerializeField] private float _maxStagger = 10f;
    [SerializeField] private InputReader _input;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
    }

    public float GetStagger()
    {
        return _staggerAmount;
    }

    public void SetStagger(float stagger)
    {
        _staggerAmount = stagger;
        EnsureStagger();
    }

    public void AlterStagger(float deltaStagger)
    {
        _staggerAmount += deltaStagger;
        EnsureStagger();
    }

    private void UpdateStagger()
    {
        _staggerAmount -= Time.deltaTime;
        EnsureStagger();
    }

    private void EnsureStagger()
    {
        if(_staggerAmount < 0f)
        {
            _staggerAmount = 0f;
        }
        else if(_staggerAmount > _maxStagger)
        {
            _staggerAmount = _maxStagger;
        }
    }

    void Update()
    {
        UpdateStagger();
        if(_input != null && _staggerAmount > 0f)
        {
            _input.NeutralizeInputs();
        }
    }
}
