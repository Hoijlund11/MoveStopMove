using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public List<Sound> musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSoure;

    public void PlaySFX(string name)
    {
        foreach(Sound s in sfxSounds)
        {
            if (s.name == name)
            {
                sfxSoure.clip = s.clip;
                sfxSoure.Play();
            }
        }
    }

    public void PlayMusic(string name)
    {
        foreach (Sound s in musicSounds)
        {
            if (s.name == name)
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
    }
}
