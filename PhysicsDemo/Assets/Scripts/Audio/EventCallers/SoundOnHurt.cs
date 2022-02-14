using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHurt : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    private void OnEnable() => PlayerHitReaction.OnAnyCharacterHit += PlayHitAudio;
    private void OnDisable() => PlayerHitReaction.OnAnyCharacterHit -= PlayHitAudio;
    private void PlayHitAudio() => SoundManager.Instance.PlaySound(_clip);
}
