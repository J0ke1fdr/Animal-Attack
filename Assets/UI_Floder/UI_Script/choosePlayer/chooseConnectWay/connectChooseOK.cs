using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class connectChooseOK : MonoBehaviour {

    public void onButtonClick()
    {

        switch(gameObject.name)
        {
            case "backButton":Back();break;
            case "oKButton": submitChoosedPlayer(); break;
        }
    }

    private void Back()
    {
        if(MenuSceneManager.gameWay == 0)
        {
            //返回到主菜单
            MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
            MenuSceneManager.mainMenuScene.gameObject.SetActive(true);           
        }
    }

    private void submitChoosedPlayer()
    {
        Debug.Log("进入submitChoosedPlayer:" + "提交" + MenuSceneManager.choosedPlayer);
        MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
        MenuSceneManager.chooseScene.gameObject.SetActive(true);
    }
}
