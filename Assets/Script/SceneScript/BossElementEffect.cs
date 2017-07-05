using UnityEngine;
using System.Collections;

public class BossElementEffect : MonoBehaviour
{
    public GameObject boss;

    private void Start()
    {
        MusicPlay();
        GetComponent<ParticleSystem>().Play();
        StartCoroutine("AppearBoss");
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator AppearBoss()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(boss, transform.position, Quaternion.identity);
    }

    public void MusicPlay()
    {
        bool musicPlay = PlayerPrefs.GetInt("CharacterMusicSetting", 1) == 1 ? true : false;
        if (musicPlay)
            GetComponent<AudioSource>().Play();
    }
}