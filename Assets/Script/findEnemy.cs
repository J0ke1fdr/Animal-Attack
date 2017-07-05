using UnityEngine;
using System.Collections;

public class findEnemy : MonoBehaviour
{
    private GameObject currentEnemy = null;
    public CharacterController controller;
    private int health;
    public int healthRatio;
    public GameObject boom;
    private bool die = false;
    private bool canWalk = true;
    private float currentTime = 0;
    private Vector3 targetPosition;
    private float randomMoveTime;
    private LevelManager levelManager = null;
    private LineLevelManager linelevelManager = null;
    private int level = 0;
    private float speed = 0.007f;
    private int damage = 10;
    public GameObject bloodbag;
    public GameObject randbox;

    private AudioSource audioSource;

    // Use this for initialization
    private void Start()
    {
        if (gameObject.name != "Pig")
            audioSource = GetComponent<AudioSource>();
        try
        {
            levelManager = GameObject.Find("CreateAnimalPoints").GetComponent<LevelManager>();
        }
        catch
        {
            linelevelManager = GameObject.Find("LineCreateAnimalPoints").GetComponent<LineLevelManager>();
        }
        controller = GetComponent<CharacterController>();
        if (levelManager != null)
            health = 200 * healthRatio + levelManager.getLevel() * 20 * healthRatio;
        else
            health = 200;
        targetPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (currentEnemy != null && canWalk)
        {
            //Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            /*if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 60)
            {
                currentEnemy = null;
            }
            else*/
            {
                Vector3 tempPosition = new Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z);
                transform.LookAt(tempPosition);
                controller.Move((currentEnemy.transform.position - transform.position) * speed);
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

    private void Update()
    {
        if (levelManager != null)
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
        if (gameObject.name != "Pig" && !audioSource.isPlaying && CanPlay())
            audioSource.Play();
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
                GameObject Boom = (GameObject)Instantiate(boom, transform.position, transform.rotation);

                if (levelManager != null)
                    levelManager.AnimalDie(gameObject);
                else
                    linelevelManager.AnimalDie(gameObject);
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

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}