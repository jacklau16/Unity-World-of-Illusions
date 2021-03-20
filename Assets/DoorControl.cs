using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject cassetteObject;
    private Animator doorAnimator;
    private AudioSource audioDoorOpening;
    private AudioSource audioDoorClosing;
    private AudioSource audioDoorUnlock;
    private AudioSource audioAccessDenied;
    private AudioSource[] sounds;

    void Start()
    {
        doorAnimator = doorObject.GetComponent<Animator>();
        doorAnimator.SetBool("hasKey", false);
        audioDoorUnlock = doorObject.GetComponents<AudioSource>()[0];
        audioAccessDenied = doorObject.GetComponents<AudioSource>()[1];
        audioDoorOpening = doorObject.GetComponents<AudioSource>()[2];

    }

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        doorAnimator.SetBool("hasKey", true);
    //        Debug.Log("Triggered!!");
    //    }

    private void OnMouseDown()
    {
        if (GlobalState.hasKey)
        {
            doorAnimator.SetBool("hasKey", true);
            PlayDoorUnlockSound();
            StartCoroutine(PlayDelayedDoorOpeningSound(1.5f));
            StartCoroutine(HideObject(4));
        } else
        {
            PlayAccessDeniedSound();
        }
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

    public void PlayAccessDeniedSound()
    {
        audioAccessDenied.Play();
    }

    // Wait for N seconds and hide the display object 
    // StartCoroutine(HideObjects(displayDurationInSecond));
    IEnumerator HideObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);

        // Enable the dinosaur sound
        cassetteObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator PlayDelayedDoorOpeningSound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayDoorOpeningSound();
    }
}
