using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundEffect : MonoBehaviour
{
    public AudioSource audioDoorOpening;
    public AudioSource audioDoorClosing;
    public AudioSource audioDoorUnlock;

    private void Start()
    {

    }
    public void PlayDoorOpeningSound()
    {
        audioDoorOpening.Play();
        Debug.Log("Playing door OPENING sound");
    }

    public void PlayDoorClosingSound()
    {
        audioDoorClosing.Play();
        Debug.Log("Playing door CLOSING sound");
    }

    public void PlayDoorUnlockSound()
    {
        audioDoorUnlock.Play();
    }

}