using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChestOpen : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    private void OnEnable() => Chest.HitChest += ChestOpenSound;
    private void OnDisable() => Chest.HitChest -= ChestOpenSound;
    private void ChestOpenSound() => SoundManager.Instance.PlaySound(_clip);
}
