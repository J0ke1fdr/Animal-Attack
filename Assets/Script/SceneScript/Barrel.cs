using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour
{
    public float health = 300f;
    public GameObject specialEffect;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
            UpdateStatus();
    }

    private void UpdateStatus()
    {
        GameObject effect = Instantiate(specialEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}