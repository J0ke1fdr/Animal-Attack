using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour
{
    // Use this for initialization

    private void Start()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * 100;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(0, 4f), Random.Range(-1.2f, 1.2f));
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -4, 0));
    }
}