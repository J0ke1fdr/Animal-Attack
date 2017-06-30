﻿using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

    

    public float basicATK = 10f;
    public float intervalAttackTime = 0.1f;

    private float timeRecord;
    private bool attack = false;
    private Animator anim;
    private AnimatorStateInfo stateInfo;
    private PlayerControl playerControl;
    private PlayerStatusfixed playerStatus;

    void Start ()
    {
        anim = GetComponent<Animator>();
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatusfixed>();

        timeRecord = Time.time;
    }
	
	void Update ()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Base Layer.saw_idle") && playerControl.CheckAttack())
        {
            attack = true;

            anim.SetBool("attack", true);
            anim.SetBool("idle", false);
        }
        if(stateInfo.IsName("Base Layer.saw_attack") && !playerControl.CheckAttack())
        {
            attack = false;

            anim.SetBool("attack", false);
            anim.SetBool("idle",true);
        }
	}

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy" && attack)
        {
            if(Time.time > timeRecord + intervalAttackTime)
            {
                timeRecord = Time.time;

                playerStatus.BulletConsume();
                //Debug.Log("ATK: " + basicATK);
                col.gameObject.SendMessage("ApplyDamage", basicATK);
            }
        }
    }
}
