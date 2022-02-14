using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCoin : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    private void OnEnable() => CoinCollector.CoinPickup += CoinSound;
    private void OnDisable() => CoinCollector.CoinPickup -= CoinSound;
    void CoinSound() => SoundManager.Instance.PlaySoundWithPitch(_clip, Random.Range(-100f, 100f));
}
