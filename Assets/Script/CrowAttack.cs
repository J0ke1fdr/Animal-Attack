using UnityEngine;
using System.Collections;

public class CrowAttack : MonoBehaviour {
    /*
    public bool attack_flag = false;
    private float lastTime = 0;
    private float currentTime = 0;
    private Collider target = null;
    */

    //public CharacterController controller;
    //public Animator anim;
    //public findEnemy find_enemy;
    public GameObject crow;
    private bool wantAttack = false;
    private bool attack = false;
    private bool attackInCD = false;

    private findEnemy find_enemy;
    private CharacterController controller;
    private Animator anim;
    private AnimatorStateInfo stateInfo;

    void Start ()
    {
        //attack_flag = true;
        //anim = GetComponent<Animator>();
        anim = crow.GetComponent<Animator>();
        find_enemy = crow.GetComponent<findEnemy>();
        controller = crow.GetComponent<CharacterController>();

    }

    void Update()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.IsName("Base Layer.crow_idle"))
            attackInCD = false;
        //空闲状态转走动
        if(stateInfo.IsName("Base Layer.crow_idle") && controller.velocity.magnitude != 0)
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        //走动状态转空闲
        if(stateInfo.IsName("Base Layer.crow_walk") && controller.velocity.magnitude == 0)
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
        }

        //空闲、走动状态转攻击状态
        if( (stateInfo.IsName("Base Layer.crow_idle") || stateInfo.IsName("Base Layer.crow_walk"))  && wantAttack)
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
            anim.SetBool("attack", true);
        }

        //攻击状态下
        if(stateInfo.IsName("Base Layer.crow_attack"))
        {
            attack = true;
            //controller.velocity = Vector3.zero;
            find_enemy.StopWalk();
        }
        else
        {
            attack = false;
            find_enemy.StartWalk();
        }
            
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            wantAttack = true;
            if(attack && !attackInCD)
            {
                //col.SendMessage("ApplyDamage", 34);
                attackInCD = true;

                Debug.Log("crow attack");
            }               
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            wantAttack = false;
    }
    /*
	void Update ()
    {
       
        currentTime += Time.deltaTime;
        if(target != null && (currentTime - lastTime > 0.25) && attack_flag)
        {
            target.SendMessage("ApplyDamage", 34);
            Debug.Log("crow Attack!!");
            attack_flag = false;
        }
        if (currentTime - lastTime > 0.35)
        {
            attack_flag = true;
            lastTime = currentTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && attack_flag)
        {
            target = other;
        }
        else
        {
            target = null;  
        }
    }
    */
}
