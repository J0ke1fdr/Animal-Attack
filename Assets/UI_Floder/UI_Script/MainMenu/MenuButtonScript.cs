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
        if(gameObject.name == "StartGameAlone")
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
       
        //直接选择角色，把选择方式设为0
        MenuSceneManager.mainMenuScene.gameObject.SetActive(false);
        MenuSceneManager.choosePlayerScene.gameObject.SetActive(true);
        MenuSceneManager.connectScene.gameObject.SetActive(false);

        MenuSceneManager.gameWay = 0;//单人

        Debug.Log("单人游戏");
    }

    private void StarGameWithOthers()
    {
        MenuSceneManager.mainMenuScene.gameObject.SetActive(false);
        MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
        MenuSceneManager.connectScene.gameObject.SetActive(true);

        MenuSceneManager.gameWay = 1;//多人

        Debug.Log("多人游戏");
    }

    private void Setting()
    {
        SettingPanel.gameObject.SetActive(true);
       // SceneManager.LoadScene(SceneName);
    }
}
