using UnityEngine;
using System.Collections;

public class BossElementEffect : MonoBehaviour
{
    public GameObject boss;

    private void Start()
    {
        GetComponent<ParticleSystem>().Play();
        Instantiate(boss, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}