using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class chooseScene : MonoBehaviour {

    public void onChooseClick()
    {
        if(gameObject.name == "Level1")
        {
            choosedPlayerIndex.SceneIndex = "1";
        }
        else if(gameObject.name == "Level2")
        {
            choosedPlayerIndex.SceneIndex = "2";
        }
        Debug.Log(gameObject.name);
    }

   
}
