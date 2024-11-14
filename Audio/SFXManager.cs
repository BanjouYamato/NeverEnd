using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    AudioSource source;

    [SerializeField] List<AudioClip> collectClips = new();

    [SerializeField] List<AudioClip> playerSound = new();

    [SerializeField] List<AudioClip> inputSound = new();

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayGainItemClip(int index)
    {
        source.PlayOneShot(collectClips[index]);
    }

    public void PlayPlayerClip(int index)
    {
        source.PlayOneShot(playerSound[index]);
    }public void PlayInputClip(int index)
    {
        source.PlayOneShot(inputSound[index]);
    }
}
