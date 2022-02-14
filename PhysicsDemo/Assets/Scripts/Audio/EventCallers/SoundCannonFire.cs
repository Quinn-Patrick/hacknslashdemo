using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCannonFire : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    private void OnEnable() => Cannon.Fire += PlayFireAudio;
    private void OnDisable() => Cannon.Fire -= PlayFireAudio;
    private void PlayFireAudio() => SoundManager.Instance.PlaySound(_clip);
}