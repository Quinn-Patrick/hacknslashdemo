using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUnlockDoor : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    private void OnEnable() => LockedDoor.DoorUnlocked += PlayUnlockAudio;
    private void OnDisable() => LockedDoor.DoorUnlocked -= PlayUnlockAudio;
    private void PlayUnlockAudio() => SoundManager.Instance.PlaySound(_clip);
}
