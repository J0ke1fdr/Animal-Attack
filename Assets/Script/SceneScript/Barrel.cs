using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour
{
    public float health = 100f;

    public GameObject specialEffect;

    private void OnCollisionEnter(Collision collision)
    {
        health -= 10;
        if (health <= 0f)
            UpdateStatus();
    }

    private void UpdateStatus()
    {
        GameObject effect = Instantiate(specialEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}