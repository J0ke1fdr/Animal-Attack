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
        source.clip = footStep;
        source.Play();
    }

    public void Hurt()
    {
        source.clip = hurt;
        source.Play();
    }

    public void LowBlood()
    {
        source.clip = lowBlood;
        if (!source.isPlaying)
            source.Play();
    }

    public void Die()
    {
        source.clip = die;
        source.Play();
    }

    public void PickUp()
    {
        source.clip = pickUp;
        source.Play();
    }
}