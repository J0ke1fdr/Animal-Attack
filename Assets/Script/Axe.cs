using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {

    public PlayerControl playerControl;
    public float attackAnimPauseTime = 0.4f;
    public float basicATK = 100f;
    public float maxATK = 300f;
    public float minChargeTime = 0.4f;                      //蓄力最少时间要求
    public float maxChargeTime = 1.7f;                        //蓄力增益最大所需时间

    private float actualATK = 100f;                         
    private bool charge = false;
    private bool axeAttack = false;
    

    private float timeRecord;
    private Animator anim;
    private AnimatorStateInfo stateInfo;

    void Start ()
    {
        anim = GetComponent<Animator>();
        //stateInfo = anim.GetCurrentAnimatorStateInfo(0);
	}
	
	
	void Update ()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        //空闲状态下右手柄按下，开始蓄力
        if (stateInfo.IsName("Base Layer.axe_idle") && playerControl.CheckAttack() && !charge)
        {
            charge = true;
            timeRecord = Time.time;

            anim.SetBool("charge", true);
            anim.SetBool("finish", false);
        }
        //蓄力状态下松开，做出攻击动作
        if(stateInfo.IsName("Base Layer.axe_charge") && !playerControl.CheckAttack() && charge)
        {
            charge = false;
            axeAttack = true;
            CalActualATK();      
              
            anim.SetBool("charge", false);
            anim.SetBool("attack", true);
            
            StartCoroutine(attackFinish());
        }
        /*
        if (stateInfo.IsName("Base Layer.axe_attack"))
            axeAttack = true;
        else
            axeAttack = false;
        */
    }
    //攻击状态下停顿一会回到空闲状态
    IEnumerator attackFinish()
    {
        yield return new WaitForSeconds(attackAnimPauseTime);

        axeAttack = false;

        anim.SetBool("finish", true);
        anim.SetBool("attack", false);
    }
    //计算实际攻击力
    private void CalActualATK()
    {
        float addATK = 0f;
        float chargeTime = 0f;
        if (Time.time >= timeRecord + minChargeTime)
        {
            chargeTime = Time.time - timeRecord;
            if (chargeTime > maxChargeTime)
                chargeTime = maxChargeTime;

            addATK = (maxATK - basicATK) * chargeTime / maxChargeTime;
        }

        actualATK = basicATK + addATK;
        timeRecord = Time.time;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy" && axeAttack)
        {
            Debug.Log("ATK: " + actualATK);
        }
    }

    
}
