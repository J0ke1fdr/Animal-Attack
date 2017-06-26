using UnityEngine;
using System.Collections;

public class SubGun : MonoBehaviour {

    public GameObject subGunBullet;
    public Transform gunPoint;                              //枪口位置
    public float firerote = 0.2f;
    public int bombLoad = 100;                              //载弹量

    private PlayerControl playerControl;
    private WeaponManager weaponManager;
    private float currentfiretime;
    private bool wantfire = false;
    
    
    void Start ()
    {
        GameObject player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        weaponManager = player.GetComponent<WeaponManager>();

    }
	
	void Update ()
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
        if(bombLoad > 0)
        {
            GameObject bullet = (GameObject)Instantiate(subGunBullet, gunPoint.position, gunPoint.rotation);
            bombLoad--;
        }
        if(bombLoad <= 0)
        {
            weaponManager.WeaponBreak();
        }


    }

}
