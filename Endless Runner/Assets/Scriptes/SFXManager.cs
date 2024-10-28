using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip powerupDoubleJump;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip powerupShield;
    public void PlaySFX(string clipToPlay)
    {
        if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        }
        if(clipToPlay == "PowerupDoubleJump")
        {
            audioSource.clip = powerupDoubleJump;
        }
        if (clipToPlay == "Jump")
        { 
            audioSource = jump;
        }
        if (clipToPlay == "Land")
        {
            audioSource == land;
        }
        if (clipToPlay == "PowerupShield")
        {
            audioSource = powerupShield;
        }



        audioSource.Play();

    }
}
