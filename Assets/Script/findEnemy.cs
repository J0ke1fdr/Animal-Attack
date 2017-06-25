using UnityEngine;
using System.Collections;

public class findEnemy : MonoBehaviour {

    private GameObject currentEnemy = null;
    private CharacterController controller;
    private int health;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        health = 200;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentEnemy != null)
        {
            //Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            /*if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 60)
            {
                currentEnemy = null;
            }
            else*/
            {
                transform.LookAt(currentEnemy.transform);
                controller.Move((currentEnemy.transform.position - transform.position) * 0.007f);
            }
        }
            
            
    }

    private void OnTriggerStay(Collider other)
    {
        if(currentEnemy == null)
        {
            if(other.tag == "Player")
            {
                currentEnemy = other.gameObject;
                Debug.Log("find enemy");
            }
            
        }
        
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
