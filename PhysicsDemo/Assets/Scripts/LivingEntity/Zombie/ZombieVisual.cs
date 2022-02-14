using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVisual : AnimatedModel
{
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _transform = gameObject.transform;
        SetDirection();
        SetAnimation();
    }

    void SwipeAttackHitbox()
    {
        Vector3 pAngle = transform.eulerAngles;

        Game.HitPool.GetHitbox(_player, _player.GetCharacterController().transform.position + DirectionalVector * 1.2f, new Vector3(90f, pAngle.y + 90, 0f), 0.5f, 2, 0.15f, 1, 0.5f, 4.0f);
    }
}
