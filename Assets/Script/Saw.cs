using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour
{
    public float basicATK = 100f;
    public float intervalAttackTime = 0.3f;

    private float timeRecord;
    private bool attack = false;
    private bool damage = false;

    private Animator anim;
    private AnimatorStateInfo stateInfo;
    private PlayerControl playerControl;
    private PlayerStatusfixed playerStatus;
    private WeaponMusic weaponMusic;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatusfixed>();
        weaponMusic = GetComponent<WeaponMusic>();
        timeRecord = Time.time;
    }

    private void Update()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Base Layer.saw_idle"))
            damage = false;

        if (stateInfo.IsName("Base Layer.saw_idle") && playerControl.CheckAttack())
        {
            attack = true;

            anim.SetBool("attack", true);
            anim.SetBool("idle", false);
            weaponMusic.Fire();
        }
        if (stateInfo.IsName("Base Layer.saw_attack") && !playerControl.CheckAttack())
        {
            attack = false;
            anim.SetBool("attack", false);
            anim.SetBool("idle", true);
            weaponMusic.StopFire();
        }

        if (Time.time > timeRecord + intervalAttackTime && attack)
        {
            timeRecord = Time.time;
            damage = true;
            //damage = !damage;
        }
        else
            damage = false;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy" && damage)
        {
            playerStatus.BulletConsume();
            Debug.Log("damage at " + Time.time);
            col.gameObject.SendMessage("ApplyDamage", basicATK);
        }

        if (col.tag == "Prop" && damage)
        {
            col.gameObject.SendMessage("ApplyDamage", basicATK);
        }
    }
}