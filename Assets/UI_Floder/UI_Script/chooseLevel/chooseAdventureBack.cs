using UnityEngine;
using System.Collections;

public class chooseAdventureBack : MonoBehaviour {

    public void onBackButtonClick()
    {
        MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(false);
        MenuSceneManager.chooseModel.gameObject.SetActive(true);
    }
}
