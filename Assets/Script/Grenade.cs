using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour
{
    public GameObject explosion;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 30;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject obj = (GameObject)Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}