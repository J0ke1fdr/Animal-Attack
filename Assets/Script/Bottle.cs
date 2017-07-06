using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{
    public GameObject blood;
    public GameObject grassBroken;

    // Use this for initialization
    private void Start()
    {
        GetComponent<Rigidbody>().velocity += transform.forward * 10 + new Vector3(0, 6, 0);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.SendMessage("ApplyDamage", 34);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(grassBroken, transform.position, transform.rotation);
            for (int i = 0; i < 20; i++)
            {
                /*GameObject obj = (GameObject)Instantiate(blood, transform.position,
                       Quaternion.EulerAngles(20f, Random.Range(-5, 5), Random.Range(-5, 5)));*/
                GameObject obj = (GameObject)Instantiate(blood, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        //GameObject obj = (GameObject)Instantiate(blood, transform.position + transform.up * 0.3f, transform.rotation);
    }

    private void Update()
    {
        transform.Rotate(2, 0, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -4, 0));
    }
}