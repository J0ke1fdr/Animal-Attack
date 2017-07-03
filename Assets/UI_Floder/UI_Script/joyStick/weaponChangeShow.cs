using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class weaponChangeShow : MonoBehaviour {

    private Image weaponImg;
    private Text bulletCountShow;
    public Sprite[] weaponImgSrc;

    private void Awake()
    {
        weaponImg = GameObject.Find("weaponImg").GetComponent<Image>();
        bulletCountShow = GameObject.Find("bulletCount").GetComponent<Text>();
    }

    /// <summary>
    /// 展示当前武器图片
    /// </summary>
    /// <param name="weaponNo">武器索引</param>
    public void ShowGetWeapon(int weaponNo)
    {
        weaponImg.sprite = weaponImgSrc[weaponNo];
    }

    /// <summary>
    /// 显示当前武器子弹数量
    /// </summary>
    /// <param name="weaponCount">子弹数量</param>
    public void ShowBulletCount(int bulletCount)
    {
        bulletCountShow.text = "x " + bulletCount.ToString();
    }

}
