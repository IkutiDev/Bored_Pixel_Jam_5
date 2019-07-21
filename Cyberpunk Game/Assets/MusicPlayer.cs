using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float songDelay=5f;
    private AudioSource audioSource;
    private float timer;
    private int currentMusicClip=0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[currentMusicClip];
        audioSource.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= audioSource.clip.length+songDelay)
        {
            timer = 0;
            currentMusicClip++;
            if (currentMusicClip >= audioClips.Length)
            {
                currentMusicClip = 0;
            }
            audioSource.clip = audioClips[currentMusicClip];
            audioSource.Play();
        }
    }
}
