using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public GameObject grenade;
    public Transform gunPoint;                              //枪口位置
    public float firerote = 1.2f;                           //射速

    private PlayerControl playerControl;
    private PlayerStatusfixed playerStatus;

    private float currentfiretime;
    private bool wantfire = false;

    private Animator anim;

    //private AnimatorStateInfo stateInfo;
    private WeaponMusic weaponMusic;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerStatus = player.GetComponent<PlayerStatusfixed>();
        anim = GetComponent<Animator>();
        weaponMusic = GetComponent<WeaponMusic>();
    }

    private void Update()
    {
        if (!playerControl.CheckAttack())
        {
            wantfire = false;
        }
        if (playerControl.CheckAttack())
        {
            wantfire = true;
        }

        currentfiretime += Time.deltaTime;

        if (currentfiretime >= firerote && wantfire)
        {
            anim.SetBool("fire", true);
            currentfiretime = 0;
            Fire();
        }
        else
            anim.SetBool("fire", false);
    }

    public void Fire()
    {
        GameObject grenade_obj = (GameObject)Instantiate(grenade, gunPoint.position, gunPoint.rotation);
        playerStatus.BulletConsume();
        weaponMusic.Fire();
        //StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("fire", false);
    }
}