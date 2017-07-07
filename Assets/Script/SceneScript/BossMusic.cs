using UnityEngine;
using System.Collections;

public class BossMusic : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip hurtMusic;
    public AudioClip attackMusic;
    public AudioClip dieMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void bossHurt()
    {
        if (CanPlay())
        {
            audioSource.clip = hurtMusic;
            audioSource.Play();
        }
    }

    public void bossAttack()
    {
        if (CanPlay())
        {
            audioSource.clip = attackMusic;
            audioSource.Play();
        }
    }

    public void bossDie()
    {
        if (CanPlay())
        {
            audioSource.clip = dieMusic;
            audioSource.Play();
        }
    }

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}