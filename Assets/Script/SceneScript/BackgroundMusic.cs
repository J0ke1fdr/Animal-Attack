using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    // Use this for initialization
    private AudioSource audioSource;

    public AudioClip[] clips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[RandClip()];
        audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clips[RandClip()];
            audioSource.Play();
        }
    }

    public int RandClip()
    {
        return Random.Range(0, clips.Length);
    }
}