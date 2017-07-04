using UnityEngine;
using System.Collections;

public class PigAttack : MonoBehaviour {
    public GameObject pig;
    private bool wantAttack = false;
    private bool attack = false;
    private bool attackInCD = false;

    private findEnemy find_enemy;
    private CharacterController controller;
    private Animator anim;
    private AnimatorStateInfo stateInfo;

    void Start()
    {
        //attack_flag = true;
        //anim = GetComponent<Animator>();
        anim = pig.GetComponent<Animator>();
        find_enemy = pig.GetComponent<findEnemy>();
        controller = pig.GetComponent<CharacterController>();

    }

    void Update()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Base Layer.pig_idle"))
            attackInCD = false;
        //空闲状态转走动
        if (stateInfo.IsName("Base Layer.pig_idle") && controller.velocity.magnitude != 0)
        {
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
            anim.SetBool("idle", false);
        }
        //走动状态转空闲
        if (stateInfo.IsName("Base Layer.pig_walk") && controller.velocity.magnitude == 0)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
            anim.SetBool("idle", true);
        }

        //空闲、走动状态转攻击状态
        if ((stateInfo.IsName("Base Layer.pig_idle") || stateInfo.IsName("Base Layer.pig_walk")) && wantAttack)
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
            anim.SetBool("attack", true);
        }
        //攻击状态下
        if (stateInfo.IsName("Base Layer.pig_attack"))
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
        if (col.tag == "Player")
        {
            wantAttack = true;
            if (attack && !attackInCD)
            {
                col.SendMessage("ApplyDamage", find_enemy.getDamage()*0.5f);
                attackInCD = true;

                //Debug.Log("pig attack");
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            wantAttack = false;
            anim.SetBool("attack", false); 
            anim.SetBool("idle", true);
        }
    }
}
