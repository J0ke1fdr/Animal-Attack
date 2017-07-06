using UnityEngine;
using System.Collections;

public class chooseAdventureOK : MonoBehaviour {
    public void onEnterButtonClick()
    {
        MenuSceneManager.chooseAdventureLevelScene.gameObject.SetActive(false);
        MenuSceneManager.choosePlayerScene.gameObject.SetActive(true);
    }
}
