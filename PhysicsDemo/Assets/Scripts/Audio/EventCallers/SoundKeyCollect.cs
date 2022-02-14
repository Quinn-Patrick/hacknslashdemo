using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKeyCollect : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    private void OnEnable() => KeyCollector.KeyCollected += PlayKeyAudio;
    private void OnDisable() => KeyCollector.KeyCollected -= PlayKeyAudio;
    private void PlayKeyAudio() => SoundManager.Instance.PlaySound(_clip);
}
