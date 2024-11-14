using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("music", 1f);
        musicSource.volume = volume;
    }
}
