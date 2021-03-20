using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCassetteSound : MonoBehaviour
{
    public GameObject soundPlayer;
    public Material ledMaterial;
    AudioSource audioDinosaur;
    AudioSource audioClick;
    bool isPlaying;

    private void Start()
    {
        isPlaying = true;
        audioDinosaur = soundPlayer.GetComponent<AudioSource>();
        audioClick = soundPlayer.GetComponents<AudioSource>()[1];
        ledMaterial.EnableKeyword("_EMISSION");
    }

    private void OnMouseOver()
    {
        //Debug.Log("ToggleCassetteSound: OnMouseOver()!");

    }
    private void OnMouseDown()
    {
        audioClick.Play();
        StartCoroutine(ToggleCassettePlayer(1));
    }


    IEnumerator ToggleCassettePlayer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (isPlaying)
        {
            audioDinosaur.Stop();
            isPlaying = false;
            ledMaterial.DisableKeyword("_EMISSION");
        }
        else
        {
            audioDinosaur.Play();
            isPlaying = true;
            ledMaterial.EnableKeyword("_EMISSION");
        }
    }
}