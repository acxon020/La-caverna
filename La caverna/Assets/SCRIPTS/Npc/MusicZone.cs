using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip musicClip; // Pista de música asignada a la zona.
    private AudioSource audioSource;
    private bool playerInsideZone = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
    }

    void Update()
    {
        if (playerInsideZone && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!playerInsideZone && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = false;
        }
    }
}
