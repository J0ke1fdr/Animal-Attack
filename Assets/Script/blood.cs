using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {
    private float currentfiretime;
    // Use this for initialization
    void Start () {
        currentfiretime = 0;
        //GetComponent<Rigidbody>().velocity = transform.forward * 100;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-12, 12), Random.Range(0, 40), Random.Range(-12, 12));
        
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -40, 0));
        currentfiretime += Time.deltaTime;
        if (currentfiretime >= 1f)
            Destroy(gameObject);
       

    }
}
