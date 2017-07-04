using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour
{
    private GameObject currentEnemy = null;
    private CharacterController controller;
    private int health;
    public GameObject boom;
    public GameObject bottle;
    private float currentfiretime;
    public Transform bottle_trans;
    private bool die = false;
    private Vector3 targetPosition;
    private float randomMoveTime;
    private float currentTime = 0;
    private LevelManager levelManager = null;
    private LineLevelManager linelevelManager = null;
    public GameObject bloodbag;
    public GameObject randbox;

    // Use this for initialization
    private void Start()
    {
        try
        {
            levelManager = GameObject.Find("CreateAnimalPoints").GetComponent<LevelManager>();
        }
        catch
        {
            linelevelManager = GameObject.Find("LineCreateAnimalPoints").GetComponent<LineLevelManager>();
        }
        controller = GetComponent<CharacterController>();
        health = 200;
        targetPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
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
                if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 8)
                {
                    controller.Move(new Vector3(currentEnemy.transform.position.x - transform.position.x,
                                                transform.position.y,
                                                currentEnemy.transform.position.z - transform.position.z) * 0.005f);
                    //controller.Move((currentEnemy.transform.position - transform.position) * 0.003f);
                }
                else if (Vector3.Distance(currentEnemy.transform.position, transform.position) < 6)
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
                    controller.Move((targetPosition - transform.position) * 0.006f);
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
            if (other.tag == "Enemy")
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

    private void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && die == false)
        {
            die = true;
            GameObject obj = (GameObject)Instantiate(boom, transform.position, transform.rotation);
            if (levelManager != null)
                levelManager.AnimalDie(gameObject);
            else
                linelevelManager.AnimalDie(gameObject);
            Destroy(gameObject);
        }
    }
}