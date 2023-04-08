using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    Transform hero;
    Transform musicSource;
    AudioSource musicSourceAudioObject;
    void Start()
    {
        hero = GameObject.FindWithTag("Player").gameObject.GetComponent<Transform>();
        musicSource = gameObject.GetComponent<Transform>();
        musicSourceAudioObject = gameObject.GetComponent<AudioSource>();
        musicSourceAudioObject.volume = 0;
    }

    void Update()
    {
        float dist = Vector2.Distance(hero.position, musicSource.position);
        if (dist < 25)
        {
            if (!musicSourceAudioObject.isPlaying)
            {

                musicSourceAudioObject.Play();
            }
            musicSourceAudioObject.volume = 0.5f - ((dist - 1) / 25);
        }
        if (dist >= 25)
        {
            musicSourceAudioObject.Pause();
        }

    }
}
