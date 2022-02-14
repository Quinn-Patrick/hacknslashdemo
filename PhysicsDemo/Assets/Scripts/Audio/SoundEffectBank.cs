using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectBank : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;

    public AudioClip GetAudioClip(int index)
    {
        return _clips[index];
    }
}
