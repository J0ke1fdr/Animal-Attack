using UnityEngine;
using System.Collections;

public class Ox : MonoBehaviour {

    private GameObject currentEnemy = null;
    public CharacterController controller;
    private int health;
    public GameObject boom;
    private bool die = false;
    private bool canWalk = true;
    private float currentTime = 0;
    private Vector3 targetPosition;
    private float randomMoveTime;
    private LevelManager levelManager;
    private int level = 0;
    private float speed;
    private int damage = 10;
    public GameObject bloodbag;
    public GameObject randbox;
    private Vector3 tempPosition;

    // Use this for initialization
    private void Start()
    {
        levelManager = GameObject.Find("CreateAnimalPoints").GetComponent<LevelManager>();
        controller = GetComponent<CharacterController>();
        health = 300 + levelManager.getLevel() * 30;
        targetPosition = new Vector3(0, 0, 0);
        tempPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentEnemy != null && canWalk)
        {
            /*Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 10)
            {
                currentEnemy = null;
            }
            else*/
            {
                if (tempPosition == new Vector3(0, 0, 0) )
                {
                    tempPosition = new Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z);
                    transform.LookAt(tempPosition);
                    tempPosition = (tempPosition - transform.position);
                    Invoke("StopRun", 0.8f);
                    /*transform.LookAt(currentEnemy.transform);
                    controller.Movnew Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z);e((currentEnemy.transform.position - transform.position) * speed * 8);*/
                }
                //controller.Move((tempPosition - transform.position) * speed * 4);

                //transform.Translate(Vector3.forward * 0.2f);
                controller.Move(tempPosition * speed * 2);
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
                    controller.Move((targetPosition - transform.position) * speed);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (level != levelManager.getLevel())
        {
            level = levelManager.getLevel();
            speed = 0.006f + levelManager.getLevel() * 0.001f;
            damage = 5 + levelManager.getLevel() * 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentEnemy == null)
        {
            if (other.tag == "Player")
            {
                targetPosition = new Vector3(0, 0, 0);
                currentEnemy = other.gameObject;
            }
            //if (other.tag == "Enemy")
            {
                if (targetPosition == new Vector3(0, 0, 0))
                {
                    //Debug.Log("random move");
                    targetPosition = transform.position + new Vector3(Random.Range(-40, 40) / 10f, 0, Random.Range(-40, 40) / 10f);
                    randomMoveTime = Random.Range(8, 25) / 10f;
                    transform.LookAt(targetPosition);
                }
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPosition = new Vector3(0, 0, 0);
            StopRun();
        }
    }*/

    private void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && die == false)
        {
            die = true;
            if (gameObject)
            {
                int randint = Random.Range(0, 10);
                if (randint == 9)
                {
                    GameObject Bloodbag = (GameObject)Instantiate(bloodbag, transform.position, transform.rotation);
                    Bloodbag.GetComponent<BloodBag>().DestroyProp(20);
                }
                else if (randint == 1)
                {
                    GameObject Randbox = (GameObject)Instantiate(randbox, transform.position, transform.rotation);
                    Randbox.GetComponent<RandBox>().DestroyProp(20);
                }
                //GameObject Boom = (GameObject)Instantiate(boom, transform.position, transform.rotation);

                levelManager.AnimalDie(gameObject);
                Destroy(gameObject);
            }
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

    public int getDamage()
    {
        return damage;
    }

    private void StopRun()
    {
        currentEnemy = null;
        tempPosition = new Vector3(0, 0, 0);
    }
}
