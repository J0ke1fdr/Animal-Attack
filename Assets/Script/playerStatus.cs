using UnityEngine;
using System.Collections;

public class playerStatus : MonoBehaviour {
    private int health;
    public int[] weapon_list = { 1, 0, 0 };
    public int equip;
    //public AudioClip die_audio;
    //public AudioClip hurt_audio;
    // Use this for initialization
    void Start () {
        health = 100;
        equip = 0;
        /* equip list:
         * pistol  0
         * rifle   1
         * shotgun 2
         */
    }

    // Update is called once per frame
    void Update()
    {
        choice_equip();
    }

    void choice_equip()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //print(equip);
            do
            {
                if (++equip == weapon_list.Length)
                {
                    equip = 0;
                }
            }
            while (weapon_list[equip] <= 0);
        }
    }
}
