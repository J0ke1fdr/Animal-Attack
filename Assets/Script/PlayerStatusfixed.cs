using UnityEngine;
using System.Collections;

public class PlayerStatusfixed : MonoBehaviour
{
    public Transform handPos;                   //持武器的手的位置
    public GameObject[] weapons;                //存放各武器的预制体
    public int bulletCountTest;

    private bool[] weaponHoldingState;          //各武器持有状态,true表示拥有该武器
    private int[] weaponBulletState;            //各武器剩余子弹情况
    private int[] weaponBulletIncrement;        //各武器每次拾取时的增加量
    private GameObject inUseWeapon;             //当前使用的武器
    private int inUseWeaponIndex = 0;           //当前使用的武器编号

    private int health;
    private float timeRecord;

    private void Start()
    {
        health = 100;

        initWeaponHoldingState();           //初始化武器持有状态
        timeRecord = Time.time;
    }

    /// <summary>
    /// 初始化各武器持有状态
    /// </summary>
    private void initWeaponHoldingState()
    {
        weaponHoldingState = new bool[weapons.Length];
        weaponBulletState = new int[weapons.Length];
        weaponBulletIncrement = new int[weapons.Length];

        //默认编号为0的武器为起始武器并实例化
        weaponHoldingState[0] = true;
        weaponBulletState[0] = 1;
        inUseWeapon = (GameObject)Instantiate(weapons[0], handPos.position, handPos.rotation);
        inUseWeapon.transform.parent = handPos.transform;

        for (int i = 1; i < weaponHoldingState.Length; i++)
        {
            weaponHoldingState[i] = false;
            weaponBulletState[i] = 0;
        }
        //初始化各武器的弹药增加量
        weaponBulletIncrement[0] = 0;
        weaponBulletIncrement[1] = 20;
        weaponBulletIncrement[2] = 100;
        weaponBulletIncrement[3] = 100;
        weaponBulletIncrement[4] = 40;
        weaponBulletIncrement[5] = 10;
    }

    /// <summary>
    /// 切换武器
    /// </summary>
    public void changeWeapon()
    {
        do
        {
            if (++inUseWeaponIndex >= weapons.Length)
                inUseWeaponIndex = 0;
        }
        while (!weaponHoldingState[inUseWeaponIndex]);

        changeWeaponByIndex(inUseWeaponIndex);
    }

    /// <summary>
    /// 根据武器编号切换到对应武器
    /// </summary>
    /// <param name="index">武器编号</param>
    public void changeWeaponByIndex(int index)
    {
        if (index >= 0 && index < weapons.Length)
        {
            Destroy(inUseWeapon);
            inUseWeapon = (GameObject)Instantiate(weapons[index], handPos.position, handPos.rotation);
            inUseWeapon.transform.parent = handPos.transform;

            //Debug.Log(inUseWeapon.transform.localPosition);
        }
    }

    /// <summary>
    /// 武器损坏
    /// </summary>
    public void WeaponBreak()
    {
        weaponHoldingState[inUseWeaponIndex] = false;
        weaponBulletState[inUseWeaponIndex] = 0;
        changeWeapon();
    }

    /// <summary>
    /// 按下按钮事件
    /// </summary>
    public void OnChangeButtonClick()
    {
        Debug.Log("change weapon");

        if (Time.time > timeRecord + 0.2f)
        {
            timeRecord = Time.time;
            changeWeapon();
        }
    }

    /// <summary>
    /// 添加该编号的武器
    /// </summary>
    /// <param name="index"></param>
    public void AddWeaponByIndex(int index)
    {
        int count = weaponBulletIncrement[index];

        if (weaponHoldingState[index] == false)
        {
            weaponHoldingState[index] = true;
            weaponBulletState[index] = count;
        }
        else
        {
            weaponBulletState[index] += count;
            if (weaponBulletState[index] > count * 3)
                weaponBulletState[index] = count * 3;
        }
    }

    /// <summary>
    /// 消耗当前武器的子弹
    /// </summary>
    public void BulletConsume()
    {
        if (inUseWeaponIndex != 0)
        {
            weaponBulletState[inUseWeaponIndex] -= 1;
            if (weaponBulletState[inUseWeaponIndex] <= 0)
            {
                WeaponBreak();
            }
        }
        bulletCountTest = weaponBulletState[inUseWeaponIndex];
    }

    public int GetHealth()
    {
        return health;
    }

    private void ApplyDamage(int damage)
    {
        health -= damage;
    }

    private void ApplyHealth(int h)
    {
        health += h;
        if (health > 100)
            health = 100;
    }
}