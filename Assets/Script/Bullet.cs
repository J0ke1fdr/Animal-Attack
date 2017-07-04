using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject blood;

    // Use this for initialization
    //public GameObject man;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 20;
    }

    // Update is called once per frame
    private void Update()
    {
        //GetComponent<Rigidbody2D>().AddForce(100 * transform.up);
        //transform.LookAt(man.transform);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            GameObject blood_obj = (GameObject)Instantiate(blood, transform.position, transform.rotation);
            Destroy(blood_obj, 1);
            coll.gameObject.SendMessage("ApplyDamage", 34);
        }
        else if (coll.gameObject.tag == "Prop")
        {
            coll.gameObject.SendMessage("ApplyDamage", 34);
        }
        //GameObject obj = (GameObject)Instantiate(blood, transform.position + transform.up * 0.3f, transform.rotation);

        Destroy(gameObject);
    }
}