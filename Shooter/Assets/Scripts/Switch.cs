using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip interactionSound;
    [SerializeField] private Transform[] transforms;

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
        foreach (var item in transforms)
        {
            if (item != null)
            {
                if (item.GetComponent<Door>())
                {
                    item.GetComponent<Door>().LockUnlockDoor();
                    break;
                }
                if (item.GetComponent<IInteractable>() != null)
                    item.GetComponent<IInteractable>().Interact();
            }
        }

        ChangeLight();
        PlaySound();
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }

    private void ChangeLight()
    {
        if (_light.color == Color.green) _light.color = Color.red;
            else _light.color = Color.green;
    }
}
