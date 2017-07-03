using UnityEngine;
using System.Collections;

public class BossElementEffect : MonoBehaviour
{
    public GameObject boss;

    private void Start()
    {
        GetComponent<ParticleSystem>().Play();
        StartCoroutine("AppearBoss");
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator AppearBoss()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}