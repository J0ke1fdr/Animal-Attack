using UnityEngine;
using System.Collections;

public class findEnemy : MonoBehaviour {

    private GameObject currentEnemy = null;
    public CharacterController controller;
    private int health;
    public GameObject boom;
    private bool die = false;
    private bool canWalk = true;
    private float currentTime = 0;
    private Vector3 targetPosition;
    private float randomMoveTime;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        health = 200;
        targetPosition = new Vector3(0, 0, 0);
        
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
        else
        {
            if (targetPosition != new Vector3(0, 0, 0))
            {
                currentTime += Time.deltaTime;
                if (currentTime > randomMoveTime)
                {
                    currentTime = 0;
                    targetPosition = new Vector3(0, 0, 0);
                }
                else
                {
                    
                    controller.Move((targetPosition - transform.position) * 0.007f);
                }
            }
        }
        
        

    }



    private void OnTriggerStay(Collider other)
    {
        if(currentEnemy == null)
        {
            if (other.tag == "Player")
            {
                targetPosition = new Vector3(0, 0, 0);
                currentEnemy = other.gameObject;
            }
            if (other.tag == "Enemy")
            {
                
                if (targetPosition == new Vector3(0, 0, 0))
                {
                    //Debug.Log("random move");
                    targetPosition = transform.position + new Vector3(Random.Range(-40, 40)/10f, 0, Random.Range(-40, 40) / 10f);
                    randomMoveTime = Random.Range(8, 25) / 10f;
                    transform.LookAt(targetPosition);
                }
                    
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
