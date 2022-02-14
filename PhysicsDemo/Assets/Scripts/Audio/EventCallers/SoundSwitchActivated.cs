using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwitchActivated : MonoBehaviour
{
    [SerializeField] AudioClip _clip1;
    [SerializeField] AudioClip _clip2;
    private void OnEnable() => Switch.SwitchActivated += PlayActivationAudio;
    private void OnDisable() => Switch.SwitchActivated -= PlayActivationAudio;
    private void PlayActivationAudio()
    {
        SoundManager.Instance.PlaySound(_clip1);
        SoundManager.Instance.PlaySound(_clip2);
    }
}