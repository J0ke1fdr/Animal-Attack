using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour {

    public void onEnterButtonClick()
    {
        switch (choosedPlayerIndex.SceneIndex)
        {
            case "1": SceneManager.LoadScene(1); break;
            case "2": SceneManager.LoadScene(2); break;
        }
    }
}
