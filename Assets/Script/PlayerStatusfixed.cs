using UnityEngine;
using System.Collections;

public class PlayerStatusfixed : MonoBehaviour
{
    public Transform handPos;                   //持武器的手的位置
    public GameObject[] weapons;                //存放各武器的预制体
    //public int bulletCountTest;

    private bool[] weaponHoldingState;          //各武器持有状态,true表示拥有该武器
    private int[] weaponBulletState;            //各武器剩余子弹情况
    private int[] weaponBulletIncrement;        //各武器每次拾取时的增加量
    private GameObject inUseWeapon;             //当前使用的武器
    private int inUseWeaponIndex = 0;           //当前使用的武器编号

    public int maxHealth = 100;
    private int health;
    private float timeRecord;
    private weaponChangeShow weaponShow;
    private RoleMusicManager musicManager;
    private GameResult gameResult;
    public msgShow msg;

    private void Start()
    {
        health = maxHealth;

        initWeaponHoldingState();           //初始化武器持有状态
        timeRecord = Time.time;

        weaponShow = GameObject.Find("weaponChangeButton").GetComponent<weaponChangeShow>();
        gameResult = GameObject.Find("UIControl/otherShow/GameResult").GetComponent<GameResult>();
        musicManager = GetComponent<RoleMusicManager>();
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
        weaponBulletIncrement[1] = 100;
        weaponBulletIncrement[2] = 50;
        weaponBulletIncrement[3] = 40;
        weaponBulletIncrement[4] = 20;
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

            weaponShow.ShowGetWeapon(index);
            weaponShow.ShowBulletCount(weaponBulletState[index]);
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
        musicManager.PickUp();
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

            if (index == inUseWeaponIndex)
                weaponShow.ShowBulletCount(weaponBulletState[inUseWeaponIndex]);
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
        //bulletCountTest = weaponBulletState[inUseWeaponIndex];
        weaponShow.ShowBulletCount(weaponBulletState[inUseWeaponIndex]);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    private void ApplyDamage(int damage)
    {
        health -= damage;
        musicManager.Hurt();
        if (health <= 0)
        {
            musicManager.Die();
            gameResult.showGameOverPanel();
        }
    }

    private void Update()
    {
        if (health <= 10 && health > 0)
        {
            musicManager.LowBlood();
        }
    }

    private void ApplyHealth(int h)
    {
        musicManager.PickUpBloodBag();
        health += h;
        if (health > 100)
            health = 100;
    }

    public void ShowMsg(int index)
    {
        msg.ShowMsg(index);
    }
}