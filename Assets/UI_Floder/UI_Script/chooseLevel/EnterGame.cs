using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour {

    public void onEnterButtonClick()
    {
        //SceneManager.LoadScene(choosedPlayerIndex.choosedIndex);
        SceneManager.LoadScene(1);
    }
}
