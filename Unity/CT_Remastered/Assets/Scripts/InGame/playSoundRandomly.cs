using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundRandomly : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip shootClip;

    void Start()
    {
        
        float index = Random.Range(0, shootClip.length);
        audioSource.clip = shootClip;
        audioSource.Play();
    }
    
}