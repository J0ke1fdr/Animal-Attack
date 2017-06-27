using UnityEngine;
using System.Collections;

public class PlayerStatusfixed : MonoBehaviour {

    public Transform handPos;                   //持武器的手的位置   
    public GameObject[] weapons;                //存放各武器的预制体

    private bool[] weaponHoldingState;          //各武器持有状态,true表示拥有该武器
    private GameObject inUseWeapon;             //当前使用的武器
    private int inUseWeaponIndex = 0;           //当前使用的武器编号

    private int health;
    private float timeRecord;

    void Start()
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

        //默认编号为0的武器为起始武器并实例化
        weaponHoldingState[0] = true;
        inUseWeapon = (GameObject)Instantiate(weapons[0], handPos.position, handPos.rotation);
        inUseWeapon.transform.parent = handPos.transform;

        for (int i = 1; i < weaponHoldingState.Length; i++)
        {
            weaponHoldingState[i] = true;
        }
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
}
