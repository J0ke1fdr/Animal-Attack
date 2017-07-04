using UnityEngine;
using System.Collections;

public class chooseSceneBack : MonoBehaviour {

	public void onChooseSceneBackClick()
    {
        MenuSceneManager.chooseScene.gameObject.SetActive(false);
        MenuSceneManager.chooseModel.gameObject.SetActive(true);
        //MenuSceneManager.choosePlayerScene.gameObject.SetActive(false);
        //if (MenuSceneManager.choosedModel == 0)
        //{          
        //    MenuSceneManager.chooseScene.gameObject.SetActive(false);
        //    MenuSceneManager.chooseModel.gameObject.SetActive(true);                
        //}
        //else if(MenuSceneManager.choosedModel == 1)
        //{
        //    MenuSceneManager.chooseScene.gameObject.SetActive(true);
        //    MenuSceneManager.chooseModel.gameObject.SetActive(false);
        //}
    }
}
