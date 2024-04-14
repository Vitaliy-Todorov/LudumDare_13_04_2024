using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Changeaudio()
    {
        audio.clip = clip[0];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = SoundController.volume;
    }
}
