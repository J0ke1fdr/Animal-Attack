using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    private GameObject currentEnemy = null;
    private CharacterController controller;
    private int health;
    public GameObject boom;
    public GameObject bottle;
    private float currentfiretime;
    private bool die = false;
    private Vector3 targetPosition;
    private float randomMoveTime;
    private float currentTime = 0;
    private LevelManager levelManager = null;
    private LineLevelManager linelevelManager = null;
    private AudioSource audioSource;
    public GameObject fire;
    private bool onFire = false;
    private bool wantFire = false;
    private GameObject fire_obj;
    public Transform mousePosition;
    private Animator anim;
    private AnimatorStateInfo stateInfo;
    public GameObject dieMusic;
    private GameResult gameResult;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        try
        {
            levelManager = GameObject.Find("CreateAnimalPoints").GetComponent<LevelManager>();
            gameResult = null;
        }
        catch
        {
            linelevelManager = GameObject.Find("LineCreateAnimalPoints").GetComponent<LineLevelManager>();
            gameResult = GameObject.Find("UIControl/otherShow/GameResult").GetComponent<GameResult>();
        }
        controller = GetComponent<CharacterController>();
        health = 20000;
        targetPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        /* stateInfo = anim.GetCurrentAnimatorStateInfo(0);
         if(stateInfo.IsName("Base Layer.dragon_attack"))
         {
         }*/
        if (currentEnemy != null)
        {
            //Debug.Log(Vector3.Distance(currentEnemy.transform.position, transform.position));
            /*if (Vector3.Distance(currentEnemy.transform.position, transform.position) > 60)
            {
                currentEnemy = null;
            }
            else*/
            {
                //if (Vector3.Distance(currentEnemy.transform.position, transform.position) < 6 && currentfiretime >= 3 && currentfiretime <= 5)

                if (currentfiretime >= 3 && currentfiretime <= 3.7f)
                {
                    if (!wantFire)
                    {
                        anim.SetBool("walk", false);
                        anim.SetBool("idle", true);
                        anim.SetBool("charge", true);
                        wantFire = true;
                    }
                }
                else if (currentfiretime >= 3.7f && currentfiretime <= 6)
                {
                    /*controller.Move(new Vector3(currentEnemy.transform.position.x - transform.position.x,
                                               0,
                                               currentEnemy.transform.position.z - transform.position.z) * 0.001f);*/
                    if (!onFire)
                    {
                        anim.SetBool("walk", false);
                        anim.SetBool("idle", false);
                        anim.SetBool("charge", false);
                        fire_obj = (GameObject)Instantiate(fire, mousePosition.position, mousePosition.rotation);
                        fire_obj.transform.parent = transform;
                        onFire = true;
                    }
                }
                else if (currentfiretime >= 6)
                {
                    Destroy(fire_obj);
                    currentfiretime = 0;
                    onFire = false;
                    wantFire = false;
                    anim.SetBool("idle", true);
                    //anim.SetBool("charge", false);
                    anim.SetBool("walk", true);
                }
                else
                {
                    //anim.SetBool("charge", false);
                    //anim.SetBool("idle", true);

                    transform.LookAt(new Vector3(currentEnemy.transform.position.x, transform.position.y, currentEnemy.transform.position.z));
                    controller.Move(new Vector3(currentEnemy.transform.position.x - transform.position.x,
                                                0,
                                               currentEnemy.transform.position.z - transform.position.z) * 0.008f);
                }
                currentfiretime += Time.deltaTime;
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
                    anim.SetBool("walk", true);
                    anim.SetBool("charge", false);
                    anim.SetBool("idle", false);
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
        if (!audioSource.isPlaying && CanPlay())
            audioSource.Play();
        health -= damage;
        if (health <= 0 && die == false)
        {
            die = true;
            Instantiate(dieMusic, transform.position, transform.rotation);
            GameObject obj = (GameObject)Instantiate(boom, transform.position, transform.rotation);
            BossDie();
            if (levelManager != null)
                levelManager.AnimalDie(gameObject);
            else
                linelevelManager.AnimalDie(gameObject);
            Destroy(gameObject);
        }
    }

    private void BossDie()
    {
        if (gameResult != null)
        {
            gameResult.showGameWinPanel();
        }
    }

    private bool CanPlay()
    {
        return PlayerPrefs.GetInt("CharacterMusicSetting") == 0 ? false : true;
    }
}