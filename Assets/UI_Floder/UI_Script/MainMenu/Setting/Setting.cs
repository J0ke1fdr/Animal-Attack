using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {

    public RectTransform soundSetting;

    private void Awake()
    {
        soundSetting = GameObject.Find("soundEffect").GetComponent<RectTransform>();
    }
    // Use this for initialization
    void Start () {
        soundSetting.gameObject.SetActive(false);
	}
	
	public void onSettingClick()
    {
        if(!soundSetting.gameObject.activeSelf)
        {
            soundSetting.gameObject.SetActive(true);
        }
        else
        {
            soundSetting.gameObject.SetActive(false);
        }
        
    }
}
