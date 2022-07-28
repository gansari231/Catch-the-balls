using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonGeneric<AudioManager>
{
    [SerializeField]
    AudioSource _collectableAudio;

    public void PlayCollectableSound()
    {
        _collectableAudio.Play();
    }
}
