using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCassetteSound : MonoBehaviour
{
    public GameObject soundPlayer;
    public Material ledMaterial;
    AudioSource audioSource;
    bool isPlaying;

    private void Start()
    {
        isPlaying = true;
        audioSource = soundPlayer.GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        //Debug.Log("ToggleCassetteSound: OnMouseOver()!");
        
    }
    private void OnMouseDown()
    {
        //Debug.Log("ToggleCassetteSound: MouseClick!");
        if (isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
            ledMaterial.DisableKeyword("_EMISSION");
        }
        else
        {
            audioSource.Play();
            isPlaying = true;
            ledMaterial.EnableKeyword("_EMISSION");
        }
    }
}
