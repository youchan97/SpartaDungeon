using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonManager<SoundManager>
{
    [SerializeField] AudioSource bgmAudio;
    [SerializeField] AudioSource effectAudio;

    public void ChangeBgmVolume(float value)
    {
        bgmAudio.volume = value;
    }

    public void ChangeEffectVolume(float value)
    {
        effectAudio.volume = value;
    }
}
