using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : LivingEntity, IBouncingEntity
{
    public float _targetAngle = 280f;
    private float _bounceTimer = 0f;
    public float _maxBounceTimer = 0.0f;
    public Vector3 _lastNormal = Vector3.zero;
    public List<Orbiter> _orbiters = new List<Orbiter>();
    public int phase = 0;
    public Hitbox box;

    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        box = Game.HitPool.GetHitbox(this, _characterController.transform.position, Vector3.zero, 1.5f, 0, 99999999, 1, 0.1f, 4f);
        _isPlayer = false;

        _state = new StateBossPhase1(_inputReader, this, _model);
        
        foreach(Orbiter o in _orbiters)
        {
            o._boss = this;
        }

        StoreSelf();
    }

    void Update()
    {
        _bounceTimer -= Time.deltaTime;
        _state = _state.InterpretInput();
    }

    

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        Vector3 normal = collision.normal;
        Bounce(normal);
    }

    public void Bounce(Vector3 normal)
    {
        if (normal.y < 0.001 && _bounceTimer <= 0 && normal != _lastNormal)
        {
            _lastNormal = normal;
            _bounceTimer = _maxBounceTimer;
            float x;

            _ = Mathf.Abs(normal.x) < 0.000001 ? x = 0.000001f : x = normal.x; //Ensure that it will not divide by zero.

            float z = normal.z;

            float normalAngle = Mathf.Rad2Deg * Mathf.Atan(z / x);

            _targetAngle = normalAngle + (normalAngle - (_targetAngle - 180));
        }
    }

    public void Bounce(float normalAngle)
    {
        _targetAngle = normalAngle + (normalAngle - (_targetAngle - 180));
    }

    public bool CanBounce()
    {
        return (_bounceTimer <= 0);
    }

    public void ForceDirection(float angle)
    {
        _targetAngle = angle;
        _lastNormal = Vector3.zero;
    }

    public List<Orbiter> GetOrbiters()
    {
        return _orbiters;
    }
}
