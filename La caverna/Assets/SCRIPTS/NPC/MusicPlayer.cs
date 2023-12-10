using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip; // Pista de música asignada al personaje.
    private AudioSource audioSource;
    private bool playerInRange = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
    }

    void Update()
    {
        if (playerInRange && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!playerInRange && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
