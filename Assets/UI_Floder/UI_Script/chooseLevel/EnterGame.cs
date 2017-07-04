using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour {

    public void onEnterButtonClick()
    {
        MenuSceneManager.chooseScene.gameObject.SetActive(false);
        MenuSceneManager.choosePlayerScene.gameObject.SetActive(true);
    }
}
