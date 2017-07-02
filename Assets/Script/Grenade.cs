using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

    public GameObject explosion;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 30;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject obj = (GameObject)Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
