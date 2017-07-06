using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class connectChooseOK : MonoBehaviour
{
    private Text msgShow;

    private void Awake()
    {
        msgShow = GameObject.Find("errorMsg").GetComponent<Text>();
    }

    private void Start()
    {
        msgShow.gameObject.SetActive(false);
    }

    public void onButtonClick()
    {
        switch (gameObject.name)
        {
            case "backButton": Back(); break;
            case "oKButton": submitChoosedPlayer(); break;
        }
    }

    private void Back()
    {
        if (MenuSceneManager.gameWay == 0)
        {
            if (MenuSceneManager.choosedModel == 0)
            {
                MenuSceneManager.mainMenuScene.gameObject.SetActive(false);
                MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
                MenuSceneManager.chooseModel.gameObject.SetActive(true);
                MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(false);
                MenuSceneManager.chooseScene.gameObject.SetActive(false);
            }
            else if (MenuSceneManager.choosedModel == 1)
            {
                MenuSceneManager.chooseScene.gameObject.SetActive(true);
                MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
                MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(false);
                MenuSceneManager.chooseModel.gameObject.SetActive(false);
                MenuSceneManager.mainMenuScene.gameObject.SetActive(false);
            }
            //返回到主菜单
        }
    }

    private void submitChoosedPlayer()
    {
        if (MenuSceneManager.choosedPlayer <= MenuSceneManager.enablePlayerIndex)
        {
            //Debug.Log("进入submitChoosedPlayer:" + "提交" + MenuSceneManager.choosedPlayer);

            PlayerPrefs.SetInt("PlayerIndex", MenuSceneManager.choosedPlayer);

            //  int LoadScene = ++MenuSceneManager.choosedScene;

            Time.timeScale = 1;
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            msgShow.gameObject.SetActive(true);
            msgShow.text = "当前角色不可用，请通关更多关卡来解锁更多角色";

            msgShow.CrossFadeAlpha(255, 1, true);
            msgShow.CrossFadeAlpha(0, 3, true);
        }
    }
}