using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private List<AudioSource> _audioSources = new List<AudioSource>();

    public void AddAudio(AudioSource audio) => 
        _audioSources.Add(audio);

    public void SetValue(float value)
    {
        foreach (AudioSource audioSource in _audioSources) 
            audioSource.volume = value;
    }
    
    public void SetBlend(float value)
    {
        foreach (AudioSource audioSource in _audioSources) 
            audioSource.spatialBlend = 1 - value;
    }
}