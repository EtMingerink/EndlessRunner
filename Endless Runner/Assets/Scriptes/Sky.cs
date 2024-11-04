using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSounds : MonoBehaviour
{
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;
    [SerializeField] AudioSource audioSources;
    public void PlayNightSound()
    {
        audioSources.clip = nightSound;
        audioSources.Play();
    }
    public void PlayDaySound()
    {
        audioSources.clip = daySound;
        audioSources.Play();
    }
}
