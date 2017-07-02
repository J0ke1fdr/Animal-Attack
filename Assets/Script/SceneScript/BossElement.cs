using UnityEngine;
using System.Collections;

public class BossElement : MonoBehaviour
{
    // Use this for initialization
    public GameObject appearEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(appearEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}