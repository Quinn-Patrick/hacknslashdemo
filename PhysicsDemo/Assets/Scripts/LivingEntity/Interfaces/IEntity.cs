using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public Transform GetTransform();
    public ICharacterModel GetModel();
    public int GetAttackHitboxLayer();
    public State GetStateObject();
    public AudioClip GetBankedSoundEffect(int index);

}
