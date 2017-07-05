using UnityEngine;
using System.Collections;

public class RoleMusicManager : MonoBehaviour
{
    // Use this for initialization

    private AudioSource source;
    public AudioClip footStep;
    public AudioClip hurt;
    public AudioClip lowBlood;
    public AudioClip die;
    public AudioClip pickUp;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void FootStep()
    {
        if (CanPlay())
        {
            source.clip = footStep;
            source.Play();
        }
    }

    public void Hurt()
    {
        if (CanPlay())
        {
            source.clip = hurt;
            source.Play();
        }
    }

    public void LowBlood()
    {
        if (CanPlay())
        {
            source.clip = lowBlood;
            if (!source.isPlaying)
                source.Play();
        }
    }

    public void Die()
    {
        if (CanPlay())
        {
            source.clip = die;
            source.Play();
        }
    }

    public void PickUp()
    {
        if (CanPlay())
        {
            source.clip = pickUp;
            source.Play();
        }
    }

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}