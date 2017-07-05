using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chooseScene : MonoBehaviour
{
    //private Text choosedScene;

    public Sprite[] dayScenePic;
    public Sprite[] nightScenePic;

    private Image dayScene;
    private Image nightScene;


    private void Awake()
    {
        dayScene = GameObject.Find("Level2").GetComponent<Image>();
        nightScene = GameObject.Find("Level3").GetComponent<Image>();
    }

    public void onChooseClick()
    {
        //   choosedScene.text = gameObject.name;

        if (gameObject.name == "Level2")
        {
            //choosedPlayerIndex.SceneIndex = 1;
            MenuSceneManager.choosedScene = 1;

            if(dayScene.sprite != dayScenePic[1])
            {
                dayScene.sprite = dayScenePic[1];
                nightScene.sprite = nightScenePic[0];
            }
        }
        else if (gameObject.name == "Level3")
        {
            // choosedPlayerIndex.SceneIndex = 2;
            MenuSceneManager.choosedScene = 2;

            if (nightScene.sprite != nightScenePic[1])
            {
                dayScene.sprite = dayScenePic[0];
                nightScene.sprite = nightScenePic[1];
            }
        }
        else if (gameObject.name == "Level4")
        {
         //   MenuSceneManager.choosedScene = 3;
            //  choosedPlayerIndex.SceneIndex = 3;
        }
        //  Debug.Log(gameObject.name + " " + choosedPlayerIndex.SceneIndex);
    }
}