using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour
{
    public GameObject pistolBullet;
    public Transform gunPoint;                              //枪口位置
    public float firerote = 0.5f;                           //射速

    private PlayerControl playerControl;
    private PlayerStatusfixed playerStatus;

    private float currentfiretime;
    private bool wantfire = false;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        playerStatus = player.GetComponent<PlayerStatusfixed>();
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
            currentfiretime = 0;
            ShootBullets();
        }
    }

    public void ShootBullets()
    {
        GameObject bullet = (GameObject)Instantiate(pistolBullet, gunPoint.position, gunPoint.rotation);

        Destroy(bullet, 2);
        //playerStatus.BulletConsume();
    }
}