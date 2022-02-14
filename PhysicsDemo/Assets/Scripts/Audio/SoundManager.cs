using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private List<AudioClip> _clipsPlayedOnThisFrame;

    [SerializeField] private AudioSource _musicSource, _sfxSource;

    private void Awake()
    {
        _clipsPlayedOnThisFrame = new List<AudioClip>();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        _clipsPlayedOnThisFrame.Clear();
    }
    public void PlaySound(AudioClip clip)
    {
        if (clip == null || _clipsPlayedOnThisFrame.Contains(clip)) return;
        _sfxSource.PlayOneShot(clip);
        _clipsPlayedOnThisFrame.Add(clip);
    }

    public void PlaySoundWithPitch(AudioClip clip, float pitch)
    {
        _sfxSource.pitch = pitch;
        PlaySound(clip);
        _sfxSource.pitch = 1f;
    }
}
