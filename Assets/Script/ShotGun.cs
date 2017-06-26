using UnityEngine;
using System.Collections;

public class ShotGun : MonoBehaviour {

    public GameObject shotGunBullet;
    public Transform gunPoint;                              //枪口位置
    public float firerote = 0.6f;
    public int bombLoad = 40;                              //载弹量

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
        if (bombLoad > 0)
        {
            GameObject obj = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.2f, 0));
            GameObject obj2 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.2f, 0));
            GameObject obj3 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.15f, 0));
            GameObject obj4 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.15f, 0));
            GameObject obj5 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.1f, 0));
            GameObject obj6 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.1f, 0));
            GameObject obj7 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.05f, 0));
            GameObject obj8 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.05f, 0));
            GameObject obj9 = (GameObject)Instantiate(shotGunBullet, gunPoint.position, gunPoint.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y), 0));

            bombLoad--;
        }
        if (bombLoad <= 0)
        {
            weaponManager.WeaponBreak();
        }


    }



}
