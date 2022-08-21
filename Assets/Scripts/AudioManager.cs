using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource controlAudio;
    [SerializeField] private AudioClip[] audios;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void PlayAudio(int i, float volume)
    {
        controlAudio.PlayOneShot(audios[i], volume);
    }
}
