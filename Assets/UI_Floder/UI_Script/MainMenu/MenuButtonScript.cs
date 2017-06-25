using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour {

    private Image SettingPanel;

    private void Start()
    {
        if(gameObject.name == "Setting")
        {
            SettingPanel = GameObject.Find("SettingPanel").GetComponent<Image>();
            SettingPanel.gameObject.SetActive(false);
        }
        
    }
    public void onMenuButtonClick()
    {
        if(gameObject.name == "StartGameAlong")
        {
            StartNewGame();
        }
        else if(gameObject.name == "StartGameWithOthers")
        {
            StarGameWithOthers();
        }
        else if(gameObject.name == "Setting")
        {
            Setting();
        }
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void StarGameWithOthers()
    {
        SceneManager.LoadScene(2);
    }

    private void Setting()
    {
        SettingPanel.gameObject.SetActive(true);
       // SceneManager.LoadScene(SceneName);
    }
}
