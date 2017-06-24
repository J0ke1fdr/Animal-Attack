using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotgun_bullet;
    public playerStatus player;
    //private man Man;
    private float currentfiretime;
    private bool wantfire = false;
    private float firerote;
    public PlayerControl playercontrol;
   /* public AudioClip shotgun_audio;
    public AudioClip pistol_audio;
    public AudioClip rifle_audio;
    AudioSource fire;*/
    //audio part
    void Start()
    {
        //fire = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!playercontrol.CheckAttack())
        {
            wantfire = false;
        }
        if (playercontrol.CheckAttack())
        {
            wantfire = true;
        }
        switch (player.equip)
        {
            case 0: firerote = 0.5f; break;
            case 1: firerote = 0.2f; break;
            case 2: firerote = 0.6f; break;
        }
        currentfiretime += Time.deltaTime;
        if (currentfiretime >= firerote && wantfire)
        {
            currentfiretime = 0;
            shootbullets();
            wantfire = false;
        }
    }
    void shootbullets()
    {
        if (player.equip == 0)
        {
            GameObject obj = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            //AudioSource.PlayClipAtPoint(pistol_audio, transform.position);
        }
        else if (player.equip == 1)
        {
            GameObject obj = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            player.weapon_list[1]--;
            //AudioSource.PlayClipAtPoint(rifle_audio, transform.position);
        }
        else if (player.equip == 2)
        {
            /*fire.Stop();
            fire.PlayOneShot(shotgun_audio, 0.15f);*/
            player.weapon_list[2]--;
            /*GameObject obj = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.2f));
            GameObject obj2 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.2f));
            GameObject obj3 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.15f));
            GameObject obj4 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.15f));
            GameObject obj5 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.1f));
            GameObject obj6 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.1f));
            GameObject obj7 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.05f));
            GameObject obj8 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.05f));
            GameObject obj9 = (GameObject)Instantiate(shotgun_bullet, transform.position, Quaternion.EulerAngles(0, 0, -Mathf.Atan2(transform.up.x, transform.up.y)));*/
            GameObject obj = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.2f, 0));
            GameObject obj2 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.2f, 0));
            GameObject obj3 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.15f, 0));
            GameObject obj4 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.15f, 0));
            GameObject obj5= (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.1f, 0));
            GameObject obj6 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.1f, 0));
            GameObject obj7 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) + 0.05f, 0));
            GameObject obj8 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y) - 0.05f, 0));
            GameObject obj9 = (GameObject)Instantiate(shotgun_bullet, transform.position, transform.rotation * Quaternion.EulerAngles(0, -Mathf.Atan2(transform.up.x, transform.up.y), 0));
        }
        if (player.weapon_list[player.equip] <= 0)
        {
            do
            {
                if (++player.equip == player.weapon_list.Length)
                {
                    player.equip = 0;
                }
            }
            while (player.weapon_list[player.equip] <= 0);
        }
    }
}
