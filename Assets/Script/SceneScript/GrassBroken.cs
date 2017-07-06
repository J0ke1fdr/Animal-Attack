using UnityEngine;
using System.Collections;

public class GrassBroken : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
            Destroy(gameObject);
    }
}