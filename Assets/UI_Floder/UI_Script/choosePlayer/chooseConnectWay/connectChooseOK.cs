using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class connectChooseOK : MonoBehaviour
{
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
                MenuSceneManager.chooseScene.gameObject.SetActive(false);
            }
            else if (MenuSceneManager.choosedModel == 1)
            {
                MenuSceneManager.chooseScene.gameObject.SetActive(true);
                MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
                MenuSceneManager.chooseModel.gameObject.SetActive(false);
                MenuSceneManager.mainMenuScene.gameObject.SetActive(false);
            }
            //返回到主菜单
        }
    }

    private void submitChoosedPlayer()
    {
        Debug.Log("进入submitChoosedPlayer:" + "提交" + MenuSceneManager.choosedPlayer);

        PlayerPrefs.SetInt("PlayerIndex", MenuSceneManager.choosedPlayer);

        int LoadScene = ++MenuSceneManager.choosedScene;
        SceneManager.LoadScene(LoadScene);
    }
}