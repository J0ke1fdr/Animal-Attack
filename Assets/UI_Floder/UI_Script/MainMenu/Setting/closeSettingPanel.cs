using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class closeSettingPanel : MonoBehaviour {

    private Image SettingPanel;
	// Use this for initialization
	void Start () {
        SettingPanel = GameObject.Find("SettingPanel").GetComponent<Image>();
	}
	
	public void CloseSettingPanel()
    {
        SettingPanel.gameObject.SetActive(false);
    }
}
