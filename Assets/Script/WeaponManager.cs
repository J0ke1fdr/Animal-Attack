using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public Transform handPos;                   //持武器的手的位置
    public PlayerControl playerControl;
    public GameObject[] weapons;

    private GameObject inUseWeapon;
    private int inUseWeaponIndex = 0;
    private float timeRecord;

	void Start ()
    {
        //playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        //初始武器
        inUseWeapon = (GameObject)Instantiate(weapons[0], handPos.position, handPos.rotation);
        inUseWeapon.transform.parent = this.transform;

        timeRecord = Time.time;
    }

    void Update()
    {
        if(playerControl.CheckAttack())         //test//应该改成判断切换武器按钮是否按下
        {
            if (Time.time > timeRecord + 0.2f)
            {
                timeRecord = Time.time;
                changeWeapon();
            }
        }
        
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    public void changeWeapon()
    {
        inUseWeaponIndex++;
        if(inUseWeaponIndex >= weapons.Length)
            inUseWeaponIndex = 0;

        changeWeaponByIndex(inUseWeaponIndex);
    }

    /// <summary>
    /// 根据武器编号切换到对应武器
    /// </summary>
    /// <param name="index">武器编号</param>
    public void changeWeaponByIndex(int index)
    {
        if(index >= 0 && index < weapons.Length)
        {
            Destroy(inUseWeapon);
            inUseWeapon = (GameObject)Instantiate(weapons[index], handPos.position, handPos.rotation);
            inUseWeapon.transform.parent = this.transform;
            //inUseWeapon.transform.localPosition = Vector3.zero;
            Debug.Log(inUseWeapon.transform.localPosition);
        }
    }
}
