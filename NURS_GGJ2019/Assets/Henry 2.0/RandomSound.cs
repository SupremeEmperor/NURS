using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSound : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.pitch = Random.Range(.8f, 1.1f);
        source.Play();
    }
}
