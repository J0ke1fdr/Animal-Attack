using UnityEngine;
using System.Collections;

public class BossElement : MonoBehaviour
{
    // Use this for initialization
    public GameObject appearEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(appearEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}