using UnityEngine;
using System.Collections;

public class chooseModelButton : MonoBehaviour {

	public void onButtonClick()
    {
        MenuSceneManager.chooseModel.gameObject.SetActive(false);
        switch (gameObject.name)
        {
            case "Back":
                MenuSceneManager.chooseScene.gameObject.SetActive(false);
                MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(false);
                MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
                MenuSceneManager.connectScene.gameObject.SetActive(false);
                MenuSceneManager.mainMenuScene.gameObject.SetActive(true); break;
            case "OK":chooseModelOK();
                 break;

            case "chooseOK":chooseOK();break;
        }
    }

    public void chooseModelOK()
    {
        if(MenuSceneManager.choosedModel == 0)
        {
            MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(true);

        }
        else if(MenuSceneManager.choosedModel == 1)
        {
            MenuSceneManager.chooseScene.gameObject.SetActive(true);
        }
        
    }

    public void chooseOK()
    {
        if (MenuSceneManager.choosedModel == 0)
        {
            MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(true);

        }
        else if (MenuSceneManager.choosedModel == 1)
        {
            MenuSceneManager.chooseScene.gameObject.SetActive(true);
        }
    }
}
