using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class msgShow : MonoBehaviour
{
    private Text levelShowText;
    private string GunName;

    // Use this for initialization
    private void Awake()
    {
        levelShowText = GetComponent<Text>();
    }

    public void ShowMsg(int GunIndex)
    {
        switch (GunIndex)
        {
            case 1: GunName = "冲锋枪"; break;
            case 2: GunName = "电锯"; break;
            case 3: GunName = "霰弹枪"; break;
            case 4: GunName = "斧头"; break;
            case 5: GunName = "火箭筒"; break;
        }
        levelShowText.text = "获得 " + GunName;
        levelShowText.CrossFadeAlpha(255, 1, true);
        levelShowText.CrossFadeAlpha(0, 2, true);
    }
}