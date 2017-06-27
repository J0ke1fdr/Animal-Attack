using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour {

    private GameObject currentEnemy = null;
    private CharacterController controller;
    private int health;
    public GameObject boom;
    public GameObject bottle;
    private float currentfiretime;
    public Transform bottle_trans;
    private bool die = false;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        health = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy != null)
        {
            //Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            /*if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 60)
            {
                currentEnemy = null;
            }
            else*/
            {
                transform.LookAt(currentEnemy.transform);
                if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 100)
                {
                    controller.Move(new Vector3(currentEnemy.transform.position.x - transform.position.x,
                                                transform.position.y,
                                                currentEnemy.transform.position.z - transform.position.z) * 0.005f);
                    //controller.Move((currentEnemy.transform.position - transform.position) * 0.003f);
                }
                else if (Vector3.Distance(currentEnemy.transform.position, transform.position) < 80)
                {
                    controller.Move(new Vector3(transform.position.x - currentEnemy.transform.position.x,
                                                transform.position.y,
                                                transform.position.z - currentEnemy.transform.position.z) * 0.005f);
                }
                currentfiretime += Time.deltaTime;
                if (currentfiretime >= 3)
                {
                    currentfiretime = 0;
                    GameObject obj = (GameObject)Instantiate(bottle, bottle_trans.position, bottle_trans.rotation);
                }
                
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (currentEnemy == null)
        {
            if (other.tag == "Player")
            {
                currentEnemy = other.gameObject;               
            }

        }

    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && die == false)
        {
            die = true;
            GameObject obj = (GameObject)Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
