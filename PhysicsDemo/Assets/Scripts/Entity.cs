using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    public LayerMask mask;

    public int _attackHitboxLayer = 9;

    public AnimatedModel _model;

    protected State _state;

    public SoundEffectBank _soundBank;

    public void OnHit(Hitbox box){}

    public Transform GetTransform()
    {
        return transform;
    }

    public Vector3 GetVelocity()
    {
        return Vector3.zero;
    }

    public ICharacterModel GetModel()
    {
        return _model;
    }

    public State GetStateObject()
    {
        return _state;
    }

    public int GetAttackHitboxLayer()
    {
        return _attackHitboxLayer;
    }

    public AudioClip GetBankedSoundEffect(int index)
    {
        try
        {
            return _soundBank.GetAudioClip(index);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError($"Index out of bounds when trying to get banked sound effect from {this}, {e.ToString()}");
            return null;
        }
    }
}
