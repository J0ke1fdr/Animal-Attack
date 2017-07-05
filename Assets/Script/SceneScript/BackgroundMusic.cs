using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    // Use this for initialization
    private AudioSource audioSource;

    public AudioClip[] clips;

    private bool setting;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        setting = PlayerPrefs.GetInt("MusicSetting", 1) == 0 ? false : true;

        if (!setting && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying && setting)
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