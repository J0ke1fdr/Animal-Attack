using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //GetComponent<Rigidbody>().velocity = transform.forward * 100;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8, 8), Random.Range(0, 40), Random.Range(-8, 8));
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -20, 0));

    }
}
