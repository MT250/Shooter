using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip interactionSound;
    [SerializeField] private Transform[] transforms;
    [SerializeField] private UnityEvent unityEvent;

    private Light _light;
    private AudioSource _audioSource;

    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = interactionSound;
    }

    public void Interact()
    {        
        unityEvent?.Invoke();

        PlaySound();
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
