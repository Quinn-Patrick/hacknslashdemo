using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : LivingEntity
{
    public IBouncingEntity _boss;
    public float _angularVelocity;
    public float _angle;
    private float _distance = 3f;
    private float _startAngle;
    private Hitbox box;

    private float _recoveryTime;
    private float _recoveryTimeMax;

    public CharacterController _controller;

    private void Awake()
    {
        _state = new StateOrbiterAlive(_inputReader, this, _model);
        _healthSystem = GetComponent<HealthSystem>();
        _controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        _startAngle = _angle;
        box = Game.HitPool.GetHitbox(this, _controller.transform.position, Vector3.zero, 1.1f, 0, 99999999, 1, 0.1f, 4f);
    }
    void Update()
    {
        SynchronizeStates();
        Movement();
    }
    void Movement()
    {
        IncrementAngle();
        SetPosition();
    }
    void IncrementAngle()
    {
        _angle += _angularVelocity * Time.deltaTime;
        if (_angle > 360) _angle -= 360;
    }
    void SetPosition()
    {
        Vector3 curPosition = _controller.transform.position;

        float x = _boss.GetTransform().position.x + _distance * Mathf.Cos(Mathf.Deg2Rad * _angle);
        float z = _boss.GetTransform().position.z + _distance * Mathf.Sin(Mathf.Deg2Rad * _angle);

        float deltaX = x - curPosition.x;
        float deltaZ = z - curPosition.z;
        float deltaY = _boss.GetTransform().position.y - curPosition.y;
        
        _controller.Move(new Vector3(deltaX, deltaY, deltaZ));
    }
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        Vector3 normal = collision.normal;
        _boss.Bounce(normal);
    }
}
