using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCannonballExplode : MonoBehaviour
{
    [SerializeField] List<AudioClip> _clips = new List<AudioClip>();
    private void OnEnable() => Cannonball.Explode += PlayExplodeAudio;
    private void OnDisable() => Cannonball.Explode -= PlayExplodeAudio;
    private void PlayExplodeAudio() => SoundManager.Instance.PlaySound(_clips[Random.Range(0, _clips.Count-1)]);
}