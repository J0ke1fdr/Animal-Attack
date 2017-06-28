using UnityEngine;
using System.Collections;

public class findEnemy : MonoBehaviour {

    private GameObject currentEnemy = null;
    public CharacterController controller;
    private int health;
    public GameObject boom;
    private bool die = false;
    private bool canWalk = true;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        health = 200;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentEnemy != null && canWalk)
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

    public void StartWalk()
    {
        canWalk = true;
    }
    public void StopWalk()
    {
        canWalk = false;
    }

}
