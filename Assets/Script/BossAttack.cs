using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour
{
    // Use this for initialization

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (CanPlay() && !audioSource.isPlaying)
            audioSource.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("ApplyDamage", 1);
        }
    }

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}