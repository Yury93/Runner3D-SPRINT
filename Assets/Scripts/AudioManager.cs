using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource falsePlayer, runPlayer;

    public void PlayFallAudio()
    {
        falsePlayer.Play();
    }
    public void PlayRunAudio()
    {
        runPlayer.Play();
    }
}
