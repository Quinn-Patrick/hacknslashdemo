using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerVisual : AnimatedModel
{
    [SerializeField] private IKnockbackSystem _stepSystem;

    void Start()
    {
        _stepSystem = _player.GetMovementSystem().GetKnockbackSystem();
    }
    void Update()
    {
        _transform = gameObject.transform;
        SetDirection();
        SetAnimation();
    }
    public void Slash1Hitbox()
    {
        Vector3 pAngle = transform.eulerAngles;

        _player.SetLastHitbox(Game.HitPool.GetHitbox(_player, _player.GetCharacterController().transform.position + DirectionalVector * 1.2f, new Vector3(90f, pAngle.y + 90, 0f), 0.9f, 2, 0.15f, 1, 1.0f, 2.0f, 11, _player.GetBankedSoundEffect(0)));
    }
    public void Slash2Hitbox()
    {
        Vector3 pAngle = transform.eulerAngles;

        _player.SetLastHitbox(Game.HitPool.GetHitbox(_player, _player.GetCharacterController().transform.position + DirectionalVector * 1.2f, new Vector3(90f, pAngle.y + 90, 0f), 0.9f, 2, 0.15f, 1, 1.0f, 3.0f, 11, _player.GetBankedSoundEffect(0)));
    }
    public void Slash3Hitbox()
    {
        Vector3 pAngle = transform.eulerAngles;

        _player.SetLastHitbox(Game.HitPool.GetHitbox(_player, _player.GetCharacterController().transform.position + DirectionalVector * 1.2f, new Vector3(90f, pAngle.y + 90, 0f), 0.9f, 2, 0.15f, 2, 1.0f, 6.0f, 11, _player.GetBankedSoundEffect(0)));
    }
    private void AttackStep(float stepMagnitude)
    {
        if (_stepSystem == null) return;
        float pAngle = Mathf.Deg2Rad * transform.eulerAngles.y;
        _stepSystem.ApplyKnockback(new Vector3(stepMagnitude * Mathf.Sin(pAngle), 0f, stepMagnitude * Mathf.Cos(pAngle)));
    }
    private void ActionSound(AudioClip clip)
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
