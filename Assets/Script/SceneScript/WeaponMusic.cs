using UnityEngine;
using System.Collections;

public class WeaponMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Fire()
    {
        if (CanPlay())
            audioSource.Play();
    }

    public void StopFire()
    {
        audioSource.Pause();
    }

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}