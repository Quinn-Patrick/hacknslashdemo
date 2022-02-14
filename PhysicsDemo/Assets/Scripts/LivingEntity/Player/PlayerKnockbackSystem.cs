using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockbackSystem : MonoBehaviour, IKnockbackSystem
{
    private Vector3 _knockbackVector;
    [SerializeField] private float _knockbackFriction = 8f;

    void Update()
    {
        UpdateKnockback();
    }
    public void ApplyKnockback(Vector3 knockbackVector)
    {
        _knockbackVector += knockbackVector;
    }

    private void UpdateKnockback()
    {
        if (_knockbackVector.magnitude < 0.1)
        {
            _knockbackVector = Vector3.zero;
            return;
        }
        Vector3 normalizedKnockbackVector = _knockbackVector.normalized;
        _knockbackVector -= new Vector3(normalizedKnockbackVector.x * _knockbackFriction * Time.deltaTime, 0f, normalizedKnockbackVector.z * _knockbackFriction * Time.deltaTime);
    }

    public Vector3 GetKnockbackSpeed()
    {
        return _knockbackVector;
    }
}
