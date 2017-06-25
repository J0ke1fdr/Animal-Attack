using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    //public GameObject blood;
    // Use this for initialization
    //public GameObject man;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 200;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().AddForce(100 * transform.up);
        //transform.LookAt(man.transform);
    }
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", 34);
        //GameObject obj = (GameObject)Instantiate(blood, transform.position + transform.up * 0.3f, transform.rotation);
        Destroy(gameObject);
    }
}
