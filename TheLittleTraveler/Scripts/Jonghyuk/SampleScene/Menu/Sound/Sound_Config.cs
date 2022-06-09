using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Config : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource;

    public void SetbgmVolume(float volume)
    {
        bgmSource.volume = volume;

    }

    public void SetseVolume(float volume)
    {
        seSource.volume = volume;
    }

}
