using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour
{
    public Transform settingContent;

    private void Awake()
    {
        settingContent = GameObject.Find("settingContent").GetComponent<Transform>();
    }

    // Use this for initialization
    private void Start()
    {
        settingContent.gameObject.SetActive(false);
    }

    public void onSettingClick()
    {
        if (!settingContent.gameObject.activeSelf)
        {
            settingContent.gameObject.SetActive(true);
        }
        else
        {
            settingContent.gameObject.SetActive(false);
        }
    }
}