using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : LivingEntity
{
    private bool hasStarted = false;
    private Hitbox box = null;
    private Vector3 startPosition;
    void Start()
    {
        _defaultState = new StateStandZombie(_inputReader, this, _model);
        _characterController = gameObject.GetComponent<CharacterController>();
        _isPlayer = false;
        _state = new StateStandZombie(_inputReader, this, _model);
        StoreSelf();
    }
    void Update()
    {
        SynchronizeStates();
        if (box == null && !_dead)
        {
            box = Game.HitPool.GetHitbox(this, gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Vector3.zero, 0.5f, 2.5f, 9999999f, 1, 1.0f, 6f);
        }
        if (_dead)
        {
            if (box != null)
            {
                Game.HitPool.ReturnHitbox(box);
            }
            _characterController.enabled = false;
        }
    }
    private void OnEnable()
    {
        if (!hasStarted)
        {
            startPosition = transform.position;
            hasStarted = true;
        }
        Game.AddToActiveEntities(this);
        if (_dead)
        {
            gameObject.SetActive(false);
        }
        
        transform.position = startPosition;
    }
    private void OnDisable()
    {
        Game.RemoveFromActiveEntities(this);
        transform.position = startPosition;
    }
}
